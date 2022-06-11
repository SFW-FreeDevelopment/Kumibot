using Discord;
using Discord.Interactions;
using Kumibot.App.Helpers;
using Kumibot.App.Services;
using Kumibot.Database.Models.Combat;
using Kumibot.Exceptions;

namespace Kumibot.App.Interactions.Components.SelectLists.CombatSelectLists.Responses;

public class EndSinglesMatchCombatEventSelectListResponse : InteractionBase
{
    private readonly CombatService _combatService;
    private readonly FighterService _fighterService;
    
    public EndSinglesMatchCombatEventSelectListResponse(CombatService combatService, FighterService fighterService)
    {
        _combatService = combatService;
        _fighterService = fighterService;
    }

    [ComponentInteraction(Constants.EndSinglesMatchCombatEventSelectListId)]
    public async Task ComponentResponse()
    {
        try
        {
            var interaction = (IComponentInteraction)Interaction;
            var combatEventId = interaction.Data.Values.FirstOrDefault();
            var combatEvent =
                await _combatService.GetById(combatEventId ?? string.Empty);
            if (!combatEvent.Equals(null))
            {
                var selectListOptions = new Dictionary<string, string>();
                foreach (var match in combatEvent.Matches)
                {
                    var fighterOne = await _fighterService.GetById(match.FighterOneId);
                    var fighterTwo = await _fighterService.GetById(match.FighterTwoId);
                    if (!fighterOne.Equals(null) && !fighterTwo.Equals(null))
                    {
                        selectListOptions.Add($"{fighterOne.Name} vs {fighterTwo.Name}", $"{combatEvent.Id}_{match.Round}_{match.Position}");
                    }
                }
                var combatEventSelectList = SelectListHelper.GetSelectList(Constants.EndSinglesMatchMatchSelectListId, selectListOptions);
                await RespondAsync("Select the match to end:", components: combatEventSelectList.Build());
            }
            else
            {
                await ReplyAsync("Could not end event.");
            }
        }
        catch (KumibotException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}