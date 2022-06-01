using Kumibot.Database.Models.Betting;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Kumibot.Database.Repositories;

public class BettingEventRepository
{
    private readonly IMongoClient _mongoClient;

    public BettingEventRepository(IMongoClient mongoClient)
    {
        _mongoClient = mongoClient;
    }
    
    public async Task<List<BettingEvent>> GetAllBettingEvents()
    {
        var bettingEvents = await GetCollection().AsQueryable().ToListAsync();
        return bettingEvents;
    }
    
    public async Task<BettingEvent> GetBettingEventById(string id)
    {
        var bettingEvent = await GetCollection().AsQueryable()
            .FirstOrDefaultAsync(g => g.Id.Equals(id));
        return bettingEvent;
    }
    
    public async Task<BettingEvent> GetBettingEventByEventTitle(string eventTitle)
    {
        var bettingEvent = await GetCollection().AsQueryable()
            .FirstOrDefaultAsync(g => g.EventTitle.Equals(eventTitle));
        return bettingEvent;
    }

    public async Task<BettingEvent> CreateBettingEvent(BettingEvent data)
    {
        data.Id = Guid.NewGuid().ToString();
        data.Version = 1;
        data.CreatedAt = DateTime.UtcNow;
        data.UpdatedAt = data.CreatedAt;
        await GetCollection().InsertOneAsync(data);
        var gameList = await GetCollection().AsQueryable().ToListAsync();
        return gameList.FirstOrDefault(x => x.Id.Equals(data.Id));
    }
    
    public async Task<BettingEvent> UpdateBettingEvent(string id, BettingEvent data)
    {
        data.UpdatedAt = DateTime.UtcNow;
        data.Version++;
        await GetCollection().ReplaceOneAsync(x => x.Id.Equals(id), data);
        return data;
    }
    
    private IMongoCollection<BettingEvent> GetCollection()
    {
        var database = _mongoClient.GetDatabase("kumibot");
        var collection = database.GetCollection<BettingEvent>("bettingevents");
        return collection;
    }
}