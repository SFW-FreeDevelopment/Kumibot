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
    
    public async Task<IEnumerable<BettingEvent>> GetAllGames()
    {
        var bettingEvents = await GetCollection().AsQueryable().ToListAsync();
        return bettingEvents;
    }
    
    public async Task<BettingEvent> GetGameById(int id)
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
    
    private IMongoCollection<BettingEvent> GetCollection()
    {
        var database = _mongoClient.GetDatabase("kumibot");
        var collection = database.GetCollection<BettingEvent>("bettingevents");
        return collection;
    }
}