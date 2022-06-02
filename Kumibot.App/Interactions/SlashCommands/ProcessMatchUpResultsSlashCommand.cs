using Discord;
using Discord.Interactions;
using Kumibot.Database.Repositories;

namespace Kumibot.App.Interactions.SlashCommands;

public class ProcessMatchUpResultsSlashCommand: InteractionBase
{
    private readonly BettingEventRepository _bettingEventRepository;

    public ProcessMatchUpResultsSlashCommand(BettingEventRepository bettingEventRepository)
    {
        _bettingEventRepository = bettingEventRepository;
    }
    
    [SlashCommand("processmatchupresults", "Place a bet on an ongoing event's match-up")]
    public async Task ProcessMatchUpResults()
    {
        var bettingEvents = await _bettingEventRepository.GetActiveBettingEvents();
        var selectMenuBuilder = new SelectMenuBuilder().WithCustomId("process_match_up_results_event_select_list");
        foreach (var bettingEvent in bettingEvents)
        {
            selectMenuBuilder.AddOption(bettingEvent.EventTitle, bettingEvent.Id);
        }
        var builder = new ComponentBuilder().WithSelectMenu(selectMenuBuilder);
        await RespondAsync("Select the event:", components: builder.Build());
    }
}