using Discord.Interactions;
using Kumibot.App.Helpers;
using Kumibot.App.Services;
using Kumibot.Database.Models.Combat;

namespace Kumibot.App.Interactions.SlashCommands.CombatSlashCommands;
//TODO: Add code for EndMatch slash command
public class EndMatchSlashCommand : InteractionBase
{
    private readonly CombatService _combatService;

    public EndMatchSlashCommand(CombatService combatService)
    {
        _combatService = combatService;
    }

    [SlashCommand("endmatch", "Ends a match on a combat event.")]
    public async Task EndMatch()
    {
        var combatEvents = await _combatService.GetByDiscordOwner(User.Id);
        if (combatEvents.Count > 0)
        {
            var selectListOptions = combatEvents.Where(x => x.Status.Equals(CombatEventStatus.Running)).Select(x => (x.EventTitle, x.Id));
            var combatEventSelectList = SelectListHelper.GetSelectList(Constants.EndSinglesMatchCombatEventSelectListId, selectListOptions.ToDictionary(x => x.EventTitle, x=> x.Id));
            await RespondAsync("Select the event:", components: combatEventSelectList.Build());
        }
        else
        {
            await ReplyAsync($"Could not find any combat events owned by {Mention}.");
        }
    }
}