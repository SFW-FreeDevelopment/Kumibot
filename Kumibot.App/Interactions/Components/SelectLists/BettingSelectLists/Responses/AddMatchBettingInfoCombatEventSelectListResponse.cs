using Discord;
using Discord.Interactions;
using Kumibot.App.Helpers;
using Kumibot.App.Services;
using Kumibot.Database.Models.Combat;

namespace Kumibot.App.Interactions.Components.SelectLists.BettingSelectLists.Responses;

public class AddMatchBettingInfoCombatEventSelectListResponse : InteractionBase
{
    private readonly CombatService _combatService;
    private readonly FighterService _fighterService;

    public AddMatchBettingInfoCombatEventSelectListResponse(CombatService combatService, FighterService fighterService)
    {
        _combatService = combatService;
        _fighterService = fighterService;
    }

    [ComponentInteraction(Constants.AddMatchBettingInfoCombatEventSelectListId)]
    public async Task ComponentResponse()
    {
        var interaction = (IComponentInteraction)Interaction;
        var combatEventId = interaction.Data.Values.FirstOrDefault();
        var combatEvent =
            await _combatService.GetById(combatEventId ?? string.Empty);
        var matches = combatEvent.Matches;
        var selectListOptions = new Dictionary<string, string>();
        foreach (var match in matches)
        {
            var fighterOne = await _fighterService.GetById(match?.FighterOneId);
            var fighterTwo = await _fighterService.GetById(match?.FighterTwoId);
            if (match != null)
            {
                selectListOptions.Add($"{fighterOne.Name} vs {fighterTwo.Name}",
                    $"{combatEvent.Id}_{match.Round}_{match.Position}");
            }
        }
        var matchSelectList = SelectListHelper.GetSelectList(Constants.PlaceBetFighterSelectListId, selectListOptions);
        await RespondAsync("Select the match:", components: matchSelectList.Build());
    }
}