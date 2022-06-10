using Discord.Interactions;
using Kumibot.App.Helpers;
using Kumibot.App.Services;
using Kumibot.Database.Models.Combat;

namespace Kumibot.App.Interactions.SlashCommands.CombatSlashCommands;

public class AddMatchSlashCommand: InteractionBase
{
    private readonly CombatService _combatService;

    public AddMatchSlashCommand(CombatService combatService)
    {
        _combatService = combatService;
    }

    [SlashCommand("addsinglesmatch", "Adds a 1 vs 1 match to a combat event")]
    public async Task AddSinglesMatch()
    {
        var combatEvents = await _combatService.GetByDiscordOwner(User.Id);
        if (combatEvents.Count > 0)
        {
            var selectListOptions = combatEvents.Where(x => x.Status.Equals(CombatEventStatus.Created)).Select(x => (x.EventTitle, x.Id));
            var combatEventSelectList = SelectListHelper.GetSelectList(Constants.AddMatchCombatEventSelectListId, selectListOptions.ToDictionary(x => x.EventTitle, x=> x.Id));
            await RespondAsync("Select the event to add the match to:", components: combatEventSelectList.Build());
        }
        else
        {
            await ReplyAsync($"Could not find any combat events owned by {Mention}.");
        }
    }
}