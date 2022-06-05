using Discord;
using Discord.Interactions;
using Kumibot.App.Helpers;
using Kumibot.App.Services;
using Kumibot.Database.Models.Combat;
using Kumibot.Database.Repositories.Betting;

namespace Kumibot.App.Interactions.SlashCommands.BettingSlashCommands;

public class PlaceBetSlashCommand : InteractionBase
{
    private readonly CombatService _combatService;

    public PlaceBetSlashCommand(CombatService combatService)
    {
        _combatService = combatService;
    }
    
    [DefaultMemberPermissions(GuildPermission.UseApplicationCommands)]
    [SlashCommand("placebet", "Place a bet on an ongoing event's match-up", ignoreGroupNames: true)]
    public async Task PlaceBet()
    {
        var combatEvents = await _combatService.GetAll();
        if (combatEvents.Count > 0)
        {
            var selectListOptions = combatEvents.Where(x => x.Status.Equals(CombatEventStatus.Running)).Select(x => (x.EventTitle, x.Id));
            var combatEventSelectList = SelectListHelper.GetSelectList(Constants.PlaceBetCombatEventSelectListId, selectListOptions.ToDictionary(x => x.EventTitle, x=> x.Id));
            await RespondAsync("Select the event to bet on:", components: combatEventSelectList.Build());
        }
        else
        {
            await ReplyAsync($"Could not find any combat events");
        }
    }
}