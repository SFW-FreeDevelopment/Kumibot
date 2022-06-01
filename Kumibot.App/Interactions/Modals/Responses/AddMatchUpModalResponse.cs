using Discord;
using Discord.Interactions;
using Kumibot.Database.Models;
using Kumibot.Database.Models.Betting;
using Kumibot.Database.Repositories;

namespace Kumibot.App.Interactions.Modals.Responses;

public class AddMatchUpModalResponse : InteractionBase
{
    private readonly BettingEventRepository _bettingEventRepository;

    public AddMatchUpModalResponse(BettingEventRepository bettingEventRepository)
    {
        _bettingEventRepository = bettingEventRepository;
    }

    [ModalInteraction("add_match_up")]
    public async Task ModalResponse(AddMatchUpModal modal)
    {
        var bettingEvent = await _bettingEventRepository.GetBettingEventById(modal.BettingEventId);
        var position = bettingEvent.MatchUps.Count > 0 ? bettingEvent.MatchUps.Max(x => x.Position) + 1 : 1;
        //TODO: Hook Fighter repository and store fighters
        var figherOne = new Fighter {Name = modal.FighterOneName};
        var figherTwo = new Fighter {Name = modal.FighterTwoName};
        bettingEvent.MatchUps?.Add(new MatchUp
        {
            FighterOne = figherOne,
            FighterTwo = figherTwo,
            FighterOneOdds = GetOdds(modal.FighterOneOdds),
            FighterTwoOdds = GetOdds(modal.FighterTwoOdds),
            Position = position
        });
        var updatedEvent = await _bettingEventRepository.UpdateBettingEvent(bettingEvent.Id, bettingEvent);
        if (updatedEvent is not null)
        {
            // Build the message to send.
            var message =
                $"{Mention} added Match-up to {bettingEvent.EventTitle}. {modal.FighterOneName} (Odds: {modal.FighterOneOdds}) vs {modal.FighterTwoName} (Odds: {modal.FighterTwoOdds})";

            // Specify the AllowedMentions so we don't actually ping everyone.
            AllowedMentions mentions = new();
            mentions.AllowedTypes = AllowedMentionTypes.Users;

            // Respond to the modal.
            await ReplyAsync(message, allowedMentions: mentions);
        }
    }

    private static int GetOdds(string oddsString)
    {
        bool isInt;
        if (oddsString.Contains('-'))
        {
            isInt = int.TryParse(oddsString, out var negativeOdds);
            if (isInt) return negativeOdds;
        }

        if (oddsString.Contains('+'))
        {
            isInt = int.TryParse(oddsString.Replace("+", string.Empty), out var positiveOdds);
            if (isInt) return positiveOdds;
        }

        isInt = int.TryParse(oddsString, out var odds);
        return isInt ? odds : 0;
    }
}