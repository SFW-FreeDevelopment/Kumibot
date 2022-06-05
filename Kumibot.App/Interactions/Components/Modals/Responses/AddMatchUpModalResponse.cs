using Discord;
using Discord.Interactions;
using Kumibot.App.Interactions.Components.Modals.CombatModals;
using Kumibot.Database.Models.Betting;
using Kumibot.Database.Models.Combat;
using Kumibot.Database.Repositories.Betting;

namespace Kumibot.App.Interactions.Components.Modals.Responses;

public class AddMatchUpModalResponse : InteractionBase
{
    private readonly BettingEventRepository _bettingEventRepository;

    public AddMatchUpModalResponse(BettingEventRepository bettingEventRepository)
    {
        _bettingEventRepository = bettingEventRepository;
    }

    [ModalInteraction("add_match_up")]
    public async Task ModalResponse(AddSinglesMatchModal modal)
    {
        var bettingEvent = await _bettingEventRepository.GetById(modal.NeededValuesId);
        var position = bettingEvent.MatchUps.Count > 0 ? bettingEvent.MatchUps.Max(x => x.Position) + 1 : 1;
        //TODO: Hook Fighter repository and store fighters
        var fighterOne = new Fighter {Name = modal.FighterOneName};
        var fighterTwo = new Fighter {Name = modal.FighterTwoName};
        bettingEvent.MatchUps?.Add(new MatchUp
        {
            FighterOne = fighterOne,
            FighterTwo = fighterTwo,
            Position = position
        });
        var updatedEvent = await _bettingEventRepository.Update(bettingEvent.Id, bettingEvent);
        if (updatedEvent is not null)
        {
            // Build the message to send.
            var message =
                $"{Mention} added Match-up to {bettingEvent.EventTitle}.";

            // Specify the AllowedMentions so we don't actually ping everyone.
            AllowedMentions mentions = new();
            mentions.AllowedTypes = AllowedMentionTypes.Users;

            // Respond to the modal.
            await ReplyAsync(message, allowedMentions: mentions);
        }
    }
}