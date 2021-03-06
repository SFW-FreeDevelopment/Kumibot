using Discord;
using Discord.Interactions;
using Kumibot.Database.Repositories;

namespace Kumibot.App.Interactions.SlashCommands;

public class AddMatchUpSlashCommand: InteractionBase
{
    private readonly BettingEventRepository _bettingEventRepository;

    public AddMatchUpSlashCommand(BettingEventRepository bettingEventRepository)
    {
        _bettingEventRepository = bettingEventRepository;
    }
    
    [SlashCommand("addmatchup", "Add a match-up to an ongoing event")]
    public async Task AddMatchUp()
    {
        var bettingEvents = await _bettingEventRepository.GetActiveBettingEvents();
        var selectMenuBuilder = new SelectMenuBuilder().WithCustomId("add_match_up_select_list");
        foreach (var bettingEvent in bettingEvents)
        {
            selectMenuBuilder.AddOption(bettingEvent.EventTitle, bettingEvent.Id);
        }
        var builder = new ComponentBuilder().WithSelectMenu(selectMenuBuilder);
        await RespondAsync("Select the event to add a match-up to:", components: builder.Build());
    }
}