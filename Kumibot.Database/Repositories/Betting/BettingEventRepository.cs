using Kumibot.Database.Models.Betting;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Kumibot.Database.Repositories.Betting;

public class BettingEventRepository : BaseRepository<BettingEvent>
{
    public BettingEventRepository(IMongoClient mongoClient) : base(mongoClient) { CollectionName = "bettingevents"; }
    
    public async Task<List<BettingEvent>> GetActiveBettingEvents()
    {
        var bettingEvents = await GetCollection().AsQueryable().Where(x => x.IsActive).ToListAsync();
        return bettingEvents;
    }
}