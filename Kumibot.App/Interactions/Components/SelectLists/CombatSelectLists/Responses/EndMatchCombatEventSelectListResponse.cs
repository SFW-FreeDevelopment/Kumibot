using Discord;
using Discord.Interactions;
using Kumibot.App.Helpers;
using Kumibot.App.Services;
using Kumibot.Database.Models.Combat;
using Kumibot.Exceptions;

namespace Kumibot.App.Interactions.Components.SelectLists.CombatSelectLists.Responses;

public class EndMatchCombatEventSelectListResponse : InteractionBase
{
    private readonly CombatService _combatService;
    private readonly FighterService _fighterService;
    
    public EndMatchCombatEventSelectListResponse(CombatService combatService, FighterService fighterService)
    {
        _combatService = combatService;
        _fighterService = fighterService;
    }

    [ComponentInteraction(Constants.EndMatchCombatEventSelectListId)]
    public async Task ComponentResponse()
    {
        //TODO: Finish logic for getting fighter data and building select list options
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
                    //selectListOptions.Add();
                }
                var combatEventSelectList = SelectListHelper.GetSelectList(Constants.AddSinglesMatchCombatEventSelectListId, selectListOptions);
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