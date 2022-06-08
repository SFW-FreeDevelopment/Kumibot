using Discord.Interactions;
using Kumibot.App.Helpers;
using Kumibot.Database.Repositories.Combat;

namespace Kumibot.App.Interactions.SlashCommands.CombatSlashCommands;

public class EndCombatEventSlashCommand : InteractionBase
{
    private readonly CombatEventRepository _combatEventRepository;

    public EndCombatEventSlashCommand(CombatEventRepository combatEventRepository)
    {
        _combatEventRepository = combatEventRepository;
    }

    [SlashCommand("endcombatevent", "Ends a combat event.")]
    public async Task EndCombatEvent()
    {
        var combatEvents = await _combatEventRepository.GetByDiscordOwner(User.Id);
        if (combatEvents.Count > 0)
        {
            var selectListOptions = combatEvents.Select(x => (x.EventTitle, x.Id));
            var combatEventSelectList = SelectListHelper.GetSelectList("end_combat_event_select_list", selectListOptions.ToDictionary(x => x.EventTitle, x=> x.Id));
            await RespondAsync("Select the event to end:", components: combatEventSelectList.Build());
        }
        else
        {
           await ReplyAsync($"Could not find any combat events owned by {Mention}");
        }
    }
}