using Discord.Interactions;
using Discord.WebSocket;
using Kumibot.App.Helpers;
using Kumibot.App.Interactions.Components.Modals.CombatModals;
using Kumibot.App.Services;
using Kumibot.Database.Models.Combat;
using Kumibot.Database.Repositories.Combat;

namespace Kumibot.App.Interactions.SlashCommands.CombatSlashCommands;
public class StartCombatEventSlashCommand : InteractionBase
{
    private readonly CombatService _combatService;

    public StartCombatEventSlashCommand(CombatService combatService)
    {
        _combatService = combatService;
    }

    [SlashCommand("startcombatevent", "Begins a combat event.")]
    public async Task StartCombatEvent()
    {
        var combatEvents = await _combatService.GetAll();
        if (combatEvents.Count > 0)
        {
            var selectListOptions = combatEvents.Where(x => x.Status.Equals(CombatEventStatus.Created)).Select(x => (x.EventTitle, x.Id));
            var combatEventSelectList = SelectListHelper.GetSelectList(Constants.StartCombatEventCombatEventSelectListId, selectListOptions.ToDictionary(x => x.EventTitle, x=> x.Id));
            await RespondAsync("Select the event to start:", components: combatEventSelectList.Build());
        }
        else
        {
            await ReplyAsync($"Could not find any combat events.");
        }
    }
}