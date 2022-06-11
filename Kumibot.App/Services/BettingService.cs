using System.Net;
using Kumibot.Database.Models.Betting;
using Kumibot.Database.Repositories.Betting;
using Kumibot.Database.Repositories.Combat;
using Kumibot.Exceptions;

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

    public async Task<BettingEvent> GetByCombatEventId(string combatEventId)
    {
        var events = await _bettingEventRepository.GetActiveBettingEvents();
        return events.FirstOrDefault(x => x.CombatEventId.Equals(combatEventId));
    }
    
    public async Task<BettingEvent> ProcessBets(string combatEventId)
    {
        var targetEvent = await GetByCombatEventId(combatEventId);
        if (targetEvent is null) throw new KumibotException(HttpStatusCode.NotFound);
        foreach (var bet in targetEvent.Bets)
        {
            
        }
        return targetEvent;
    }
}