using Kumibot.Database.Models.Gaming;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Kumibot.Database.Repositories.Gaming;

public class GameRepository : BaseRepository<Game>
{
   public GameRepository(IMongoClient mongoClient) : base(mongoClient) { CollectionName = "games"; }
    
   public async Task<Game> GetGameBySlug(string slug)
    {
        var game = await GetCollection().AsQueryable()
            .FirstOrDefaultAsync(g => g.Slug.Equals(slug));
        return game;
    }
}