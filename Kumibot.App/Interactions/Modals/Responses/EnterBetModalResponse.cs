using Discord;
using Discord.Interactions;
using Kumibot.Database.Models.Betting;
using Kumibot.Database.Repositories;

namespace Kumibot.App.Interactions.Modals.Responses;

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
        var fighterId = long.Parse(splitValues[2]);
        var bettingEvent = await _bettingEventRepository.GetBettingEventById(bettingEventId);
        var matchUp = bettingEvent.MatchUps.FirstOrDefault(x => x.Position.Equals(matchUpPosition));
        var fighter = fighterId.Equals(1) ? matchUp?.FighterOne : matchUp?.FighterTwo;
        var dollarAmount = double.Parse(modal.BettingAmount);
        bettingEvent.Bets.Add(new Bet
        {
            Owner = User.Id,
            DollarAmount = dollarAmount,
            FighterId = fighterId,
            Fighter = fighter
        });
            var updatedEvent = await _bettingEventRepository.UpdateBettingEvent(bettingEvent.Id, bettingEvent);
        if (updatedEvent is not null)
        {
            // Build the message to send.
            var message =
                $"{Mention} placed a {dollarAmount} on {fighter} for {bettingEvent.EventTitle}.";

            // Specify the AllowedMentions so we don't actually ping everyone.
            AllowedMentions mentions = new();
            mentions.AllowedTypes = AllowedMentionTypes.Users;

            // Respond to the modal.
            await ReplyAsync(message, allowedMentions: mentions);
        }
    }
}