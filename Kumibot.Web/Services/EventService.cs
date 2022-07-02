using Kumibot.Database.Models.Combat;

namespace Kumibot.Web.Services;

public class EventService : ICombatService<CombatEvent>
{
    public Task<List<CombatEvent>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<CombatEvent> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<CombatEvent> Create(CombatEvent data)
    {
        throw new NotImplementedException();
    }

    public Task<CombatEvent> Update(string id, CombatEvent data)
    {
        throw new NotImplementedException();
    }

    public Task Delete(string id)
    {
        throw new NotImplementedException();
    }
}