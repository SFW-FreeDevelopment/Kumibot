using Kumibot.Database.Models.Combat;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Kumibot.Database.Repositories.Combat;

public class FighterRepository : BaseRepository<Fighter>
{
    public FighterRepository(IMongoClient mongoClient) : base(mongoClient) { CollectionName = "fighters"; }
    
    public async Task<Fighter> GetFighterByName(string fighterName)
    {
        var item = await GetCollection().AsQueryable()
            .FirstOrDefaultAsync(w => w.Name.Equals(fighterName));
        return item;
    }
}