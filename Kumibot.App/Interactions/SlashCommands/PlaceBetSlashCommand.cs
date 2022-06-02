using Discord;
using Discord.Interactions;
using Kumibot.Database.Repositories;

namespace Kumibot.App.Interactions.SlashCommands;

public class PlaceBetSlashCommand : InteractionBase
{
    private readonly BettingEventRepository _bettingEventRepository;

    public PlaceBetSlashCommand(BettingEventRepository bettingEventRepository)
    {
        _bettingEventRepository = bettingEventRepository;
    }
    
    [SlashCommand("placebet", "Place a bet on an ongoing event's match-up")]
    public async Task PlaceBet()
    {
        var bettingEvents = await _bettingEventRepository.GetActiveBettingEvents();
        var selectMenuBuilder = new SelectMenuBuilder().WithCustomId("place_bet_select_list");
        foreach (var bettingEvent in bettingEvents)
        {
            selectMenuBuilder.AddOption(bettingEvent.EventTitle, bettingEvent.Id);
        }
        var builder = new ComponentBuilder().WithSelectMenu(selectMenuBuilder);
        await RespondAsync("Select the event to bet on:", components: builder.Build());
    }
}