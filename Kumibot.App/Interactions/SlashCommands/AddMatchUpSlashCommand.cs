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
    
    [SlashCommand("addmatchup", "Place a bet on an ongoing event's match-up")]
    public async Task AddMatchUp()
    {
        var bettingEvents = await _bettingEventRepository.GetAllBettingEvents();
        var selectMenuBuilder = new SelectMenuBuilder().WithCustomId("add_match_up_select_list");
        foreach (var bettingEvent in bettingEvents)
        {
            selectMenuBuilder.AddOption(bettingEvent.EventTitle, bettingEvent.Id);
        }
        var builder = new ComponentBuilder().WithSelectMenu(selectMenuBuilder);
        await RespondAsync("Select the event to bet on:", components: builder.Build());
    }
}