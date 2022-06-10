using Kumibot.Database.Models.Betting;
using Kumibot.Database.Repositories.Betting;
using Kumibot.Database.Repositories.Combat;

namespace Kumibot.App.Services;

public class BettingService : IKumibotService<BettingEvent>
{
    private readonly BettingEventRepository _bettingEventRepository;
    private readonly CombatEventRepository _combatEventRepository;

    public BettingService(BettingEventRepository bettingEventRepository, CombatEventRepository combatEventRepository)
    {
        _bettingEventRepository = bettingEventRepository;
        _combatEventRepository = combatEventRepository;
    }

    public async Task<BettingEvent> ProcessBets(string eventId)
    {
        var activeEvents = await _bettingEventRepository.GetRunningBettingEvents();
        var targetEvent = activeEvents.FirstOrDefault(x => x.EventId.Equals(eventId));
        if (targetEvent is null) return targetEvent;
        foreach (var bet in targetEvent.Bets)
        {
            
        }
        return targetEvent;
    }

    public Task<List<BettingEvent>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<BettingEvent> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<BettingEvent> Create(BettingEvent data)
    {
        throw new NotImplementedException();
    }

    public Task<BettingEvent> Update(string id, BettingEvent data)
    {
        throw new NotImplementedException();
    }

    public Task Delete(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<BettingEvent> GetByEventId(string eventId)
    {
        var events = await _bettingEventRepository.GetRunningBettingEvents();
        return events.FirstOrDefault(x => x.EventId.Equals(eventId));
    }
}