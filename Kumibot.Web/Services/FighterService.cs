using Kumibot.Database.Models.Combat;

namespace Kumibot.Web.Services;

public class FighterService : ICombatService<Fighter>
{
    public Task<List<Fighter>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Fighter> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<Fighter> Create(Fighter data)
    {
        throw new NotImplementedException();
    }

    public Task<Fighter> Update(string id, Fighter data)
    {
        throw new NotImplementedException();
    }

    public Task Delete(string id)
    {
        throw new NotImplementedException();
    }
}