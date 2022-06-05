using Kumibot.Database.Interfaces;
using Kumibot.Database.Models.CombatEvent;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Kumibot.Database.Repositories;

public class CombatEventRepository : IMongoRepository<CombatEvent>
{
    private readonly IMongoClient _mongoClient;

    public CombatEventRepository(IMongoClient mongoClient)
    {
        _mongoClient = mongoClient;
    }
    
    public async Task<List<CombatEvent>> GetAll()
    {
        var combatEvents = await GetCollection().AsQueryable().ToListAsync();
        return combatEvents;
    }

    public async Task<CombatEvent> GetById(string id)
    {
        var combatEvent = await GetCollection().AsQueryable()
            .FirstOrDefaultAsync(w => w.Id.Equals(id));
        return combatEvent;
    }

    public async Task<CombatEvent> Create(CombatEvent data)
    {
        data.Id = Guid.NewGuid().ToString();
        data.Version = 1;
        data.CreatedAt = DateTime.UtcNow;
        data.UpdatedAt = data.CreatedAt;
        await GetCollection().InsertOneAsync(data);
        var combatEvents = await GetCollection().AsQueryable().ToListAsync();
        return combatEvents.FirstOrDefault(x => x.Id.Equals(data.Id));
    }

    public async Task<CombatEvent> Update(string id, CombatEvent data)
    {
        data.UpdatedAt = DateTime.UtcNow;
        data.Version++;
        await GetCollection().ReplaceOneAsync(x => x.Id.Equals(id), data);
        return data;
    }

    public Task Delete(string id)
    {
        throw new NotImplementedException();
    }

    private IMongoCollection<CombatEvent> GetCollection()
    {
        var database = _mongoClient.GetDatabase("kumibot");
        var collection = database.GetCollection<CombatEvent>("combatevents");
        return collection;
    }
}