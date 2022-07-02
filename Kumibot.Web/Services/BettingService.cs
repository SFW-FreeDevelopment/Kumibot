using Kumibot.Database.Models.Betting;

namespace Kumibot.Web.Services;

public class BettingService : ICombatService<BettingEvent>
{
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
}