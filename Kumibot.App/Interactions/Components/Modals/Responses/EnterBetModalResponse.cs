using Discord;
using Discord.Interactions;
using Kumibot.Database.Models.Betting;
using Kumibot.Database.Repositories.Betting;

namespace Kumibot.App.Interactions.Components.Modals.Responses;

public class EnterBetModalResponse : InteractionBase
{
    private readonly BettingEventRepository _bettingEventRepository;

    public EnterBetModalResponse(BettingEventRepository bettingEventRepository)
    {
        _bettingEventRepository = bettingEventRepository;
    }

    [ModalInteraction("place_bet_fighter_amount")]
    public async Task ModalResponse(EnterBetModal modal)
    {
        var splitValues = modal.NeededValues.Split('_');
        var bettingEventId = splitValues[0];
        var matchUpPosition = int.Parse(splitValues[1]);
        var fighterId = splitValues[2];
        var bettingEvent = await _bettingEventRepository.GetById(bettingEventId);
        var matchUp = bettingEvent.MatchUps.FirstOrDefault(x => x.Position.Equals(matchUpPosition));
        var fighter = matchUp?.FighterOne.Id.Equals(fighterId) ?? false ? matchUp.FighterOne : matchUp?.FighterTwo;
        var dollarAmount = double.Parse(modal.BettingAmount);
        bettingEvent.Bets.Add(new Bet
        {
            DiscordOwner = User.Id,
            DollarAmount = dollarAmount,
            FighterId = fighterId,
            MatchPosition = matchUpPosition
        });
        var updatedEvent = await _bettingEventRepository.Update(bettingEvent.Id, bettingEvent);
        if (updatedEvent is not null)
        {
            // Build the message to send.
            var message =
                $"{Mention} placed a ${dollarAmount} bet on {fighter?.Name} for {bettingEvent.EventTitle}.";

            // Specify the AllowedMentions so we don't actually ping everyone.
            AllowedMentions mentions = new();
            mentions.AllowedTypes = AllowedMentionTypes.Users;

            // Respond to the modal.
            await ReplyAsync(message, allowedMentions: mentions);
        }
    }
}