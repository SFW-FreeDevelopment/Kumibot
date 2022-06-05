using Discord;
using Discord.Interactions;
using Kumibot.Database.Repositories;

namespace Kumibot.App.Interactions.Components.SelectLists.Responses;

public class ProcessMatchUpResultsWinnerSelectListResponse: InteractionBase
{
    private readonly BettingEventRepository _bettingEventRepository;
    private readonly WalletRepository _walletRepository;

    public ProcessMatchUpResultsWinnerSelectListResponse(BettingEventRepository bettingEventRepository, WalletRepository walletRepository)
    {
        _bettingEventRepository = bettingEventRepository;
        _walletRepository = walletRepository;
    }

    [ComponentInteraction("process_match_up_results_winner_select_list")]
    public async Task ComponentResponse()
    {
        var interaction = (IComponentInteraction)Interaction;
        var valueCombo = interaction.Data.Values.FirstOrDefault();
        var splitValue = valueCombo?.Split('_');
        var bettingEventId = splitValue?[0];
        var matchUpPosition = int.Parse(splitValue?[1] ?? string.Empty);
        var fighterId = splitValue?[2];
        var bettingEvent =
            await _bettingEventRepository.GetBettingEventById(bettingEventId ?? string.Empty);
        var matchUp = bettingEvent.MatchUps.FirstOrDefault(x => x.Position.Equals(matchUpPosition));
        if (matchUp is not null)
        {
            matchUp.WinnerId = fighterId;
            foreach (var bet in bettingEvent.Bets.Where(x => !x.Processed && x.MatchUpPosition.Equals(matchUpPosition)))
            {
                var wallet = await _walletRepository.GetByDiscordOwner(bet.Owner);
                if (bet.Fighter.Id.Equals(matchUp.WinnerId))
                {
                    var odds = 0;
                    if (matchUp.WinnerId != null && matchUp.WinnerId.Equals(matchUp.FighterOne.Id)) odds = matchUp.FighterOneOdds;
                    if (matchUp.WinnerId != null && matchUp.WinnerId.Equals(matchUp.FighterTwo.Id)) odds = matchUp.FighterTwoOdds;
                    var profit = CalculateProfit(bet.DollarAmount, odds);
                    wallet.Dollars += profit;
                    var winningMessage =
                        $"<@{bet.Owner}> made ${profit} on {matchUp.FighterOne.Name} vs {matchUp.FighterTwo.Name}!";
                
                    AllowedMentions mentions = new();
                    mentions.AllowedTypes = AllowedMentionTypes.Users;
                
                    await ReplyAsync(winningMessage, allowedMentions: mentions);
                }
                else
                {
                    wallet.Dollars -= bet.DollarAmount;
                    var losingMessage =
                        $"<@{bet.Owner}> lost ${bet.DollarAmount} on {matchUp.FighterOne.Name} vs {matchUp.FighterTwo.Name}!";
                
                    AllowedMentions mentions = new();
                    mentions.AllowedTypes = AllowedMentionTypes.Users;
                
                    await ReplyAsync(losingMessage, allowedMentions: mentions);
                }

                wallet.Dollars = Math.Round(wallet.Dollars, 2, MidpointRounding.ToZero);
                await _walletRepository.Update(wallet.Id, wallet);
                bet.Processed = true;
            }

            matchUp.Finished = true;
            await _bettingEventRepository.UpdateBettingEvent(bettingEvent.Id, bettingEvent);
        }
    }

    private static double CalculateProfit(double betAmount, int odds)
    {
        var profit = odds switch
        {
            > 0 => betAmount * Math.Abs((double)odds / 100),
            < 0 => Math.Abs(betAmount / ((double)odds / 100)),
            _ => 0.00
        };

        return profit;
    }
}