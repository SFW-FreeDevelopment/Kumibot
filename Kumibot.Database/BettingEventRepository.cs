using Kumibot.Database.Models.Betting;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Kumibot.Database;

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
    
    private IMongoCollection<BettingEvent> GetCollection()
    {
        var database = _mongoClient.GetDatabase("kumibot");
        var collection = database.GetCollection<BettingEvent>("bettingevents");
        return collection;
    }
}