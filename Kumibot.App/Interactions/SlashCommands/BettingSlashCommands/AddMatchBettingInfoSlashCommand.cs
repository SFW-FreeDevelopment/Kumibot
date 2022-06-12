using Discord;
using Discord.Interactions;
using Kumibot.App.Helpers;
using Kumibot.App.Services;
using Kumibot.Database.Models.Combat;

namespace Kumibot.App.Interactions.SlashCommands.BettingSlashCommands;

public class AddMatchBettingInfoSlashCommand: InteractionBase
{
    private readonly CombatService _combatService;

    public AddMatchBettingInfoSlashCommand(CombatService combatService)
    {
        _combatService = combatService;
    }
    
    [DefaultMemberPermissions(GuildPermission.UseApplicationCommands)]
    [SlashCommand("addmatchbettinginfo", "Add betting info for a match.", ignoreGroupNames: true)]
    public async Task AddMatchBettingInfo()
    {
        var combatEvents = await _combatService.GetByDiscordOwner(User.Id);
        if (combatEvents.Count > 0)
        {
            var selectListOptions = combatEvents.Where(x => x.Status.Equals(CombatEventStatus.Running)).Select(x => (x.EventTitle, x.Id));
            var combatEventSelectList = SelectListHelper.GetSelectList(Constants.AddMatchBettingInfoCombatEventSelectListId, selectListOptions.ToDictionary(x => x.EventTitle, x=> x.Id));
            await RespondAsync("Select the event:", components: combatEventSelectList.Build());
        }
        else
        {
            await ReplyAsync($"Could not find any combat events for {Mention}");
        }
    }
}