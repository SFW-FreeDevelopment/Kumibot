using Discord;
using Discord.Interactions;
using Kumibot.App.Interactions.Modals;
using Kumibot.Database.Models.Betting;
using Kumibot.Database.Repositories;

namespace Kumibot.App.Interactions.SlashCommands;

public class AddMatchUpsToEventSlashCommand : InteractionBase
{
    private BettingEventRepository _bettingEventRepository;
    public AddMatchUpsToEventSlashCommand(BettingEventRepository bettingEventRepository)
    {
        _bettingEventRepository = bettingEventRepository;
    }
    
    [SlashCommand("addmatchupstoevent", "Add match-ups to an ongoing event.")]
    public async Task AddMatchUpsToEvent(string eventReference, int numberOfMatchUps)
    {
        BettingEvent eventToUpdate;
        var referenceIsId = Guid.TryParse(eventReference, out var id);
        if (referenceIsId)
        {
            eventToUpdate = await _bettingEventRepository.GetBettingEventById(id.ToString());
        }
        else
        {
            eventToUpdate = await _bettingEventRepository.GetBettingEventByEventTitle(eventReference);
        }

        for (var i = 0; i < numberOfMatchUps; i++)
        {
            
        }
        await Interaction.RespondWithModalAsync<CreateBettingEventModal>("add_match_ups");
    }
}