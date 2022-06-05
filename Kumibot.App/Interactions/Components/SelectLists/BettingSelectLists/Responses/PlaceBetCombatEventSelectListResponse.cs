using Discord;
using Discord.Interactions;
using Kumibot.App.Helpers;
using Kumibot.App.Services;
using Kumibot.Database.Models.Combat;

namespace Kumibot.App.Interactions.Components.SelectLists.BettingSelectLists.Responses;

public class PlaceBetCombatEventSelectListResponse : InteractionBase
{
    private readonly CombatService _combatService;
    private readonly FighterService _fighterService;

    public PlaceBetCombatEventSelectListResponse(CombatService combatService, FighterService fighterService)
    {
        _combatService = combatService;
        _fighterService = fighterService;
    }
    // TODO: Finish logic for Switch
    [ComponentInteraction(Constants.PlaceBetCombatEventSelectListId)]
    public async Task ComponentResponse()
    {
        var interaction = (IComponentInteraction)Interaction;
        var combatEventId = interaction.Data.Values.FirstOrDefault();
        var combatEvent =
            await _combatService.GetById(combatEventId ?? string.Empty);
        var matches = combatEvent.Matches;
        switch (combatEvent.Type)
        {
            case CombatEventType.FightCard:
                break;
            case CombatEventType.SingleExhibition:
                var match = matches.FirstOrDefault();
                var fighterOne = await _fighterService.GetById(match?.FighterOneId);
                var fighterTwo = await _fighterService.GetById(match?.FighterTwoId);
                var fighterOptions = new Dictionary<string, string>
                {
                    {fighterOne.Name, $"{combatEvent.Id}_{fighterOne.Id}"},
                    {fighterTwo.Name, $"{combatEvent.Id}_{fighterTwo.Id}"}
                };
                var fighterSelectList = SelectListHelper.GetSelectList(Constants.PlaceBetFighterSelectListId, fighterOptions);
                await RespondAsync("Select the fighter to bet on:", components: fighterSelectList.Build());
                break;
            case CombatEventType.Team:
                break;
            case CombatEventType.TeamTournament:
                break;
            case CombatEventType.Tournament:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}