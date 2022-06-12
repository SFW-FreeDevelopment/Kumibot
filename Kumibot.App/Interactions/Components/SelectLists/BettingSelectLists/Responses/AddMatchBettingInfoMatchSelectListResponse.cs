using Discord;
using Discord.Interactions;
using Kumibot.App.Helpers;
using Kumibot.App.Interactions.Components.Modals.BettingModals;
using Kumibot.App.Services;

namespace Kumibot.App.Interactions.Components.SelectLists.BettingSelectLists.Responses;

public class AddMatchBettingInfoMatchSelectListResponse : InteractionBase
{
    private readonly CombatService _combatService;
    private readonly FighterService _fighterService;

    public AddMatchBettingInfoMatchSelectListResponse(CombatService combatService, FighterService fighterService)
    {
        _combatService = combatService;
        _fighterService = fighterService;
    }

    [ComponentInteraction(Constants.AddMatchBettingInfoMatchSelectListId)]
    public async Task ComponentResponse()
    {
        var interaction = (IComponentInteraction)Interaction;
        var splitValues = interaction.Data.Values.FirstOrDefault()?.Split("_");
        if (splitValues != null)
        {
            var combatEventId = splitValues[0];
            var matchRound = int.Parse(splitValues[1]);
            var matchPosition = int.Parse(splitValues[2]);
            var combatEvent =
                await _combatService.GetById(combatEventId);
            var match = combatEvent.Matches.FirstOrDefault(x => x.Round.Equals(matchRound) && x.Position.Equals(matchPosition));
            var selectListOptions = new Dictionary<string, string>();
            var fighterOne = await _fighterService.GetById(match?.FighterOneId);
            var fighterTwo = await _fighterService.GetById(match?.FighterTwoId);
            if (match != null)
            {
                var modalBuilder = AddMatchBettingInfoModal.GetAddMatchBettingInfoModal(combatEvent.Id, match, fighterOne.Name, fighterTwo.Name);
                await RespondWithModalAsync(modalBuilder.Build());
            }
        }
    }
}