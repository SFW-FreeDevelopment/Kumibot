using Kumibot.Database.Models.Games;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Kumibot.Database.Repositories;

public class GameRepository
{
    private readonly IMongoClient _mongoClient;

    public GameRepository(IMongoClient mongoClient)
    {
        _mongoClient = mongoClient;
    }
    
    public async Task<IEnumerable<Game>> GetAllGames()
    {
        var games = await GetCollection().AsQueryable().ToListAsync();
        return games;
    }
    
    public async Task<Game> GetGameById(int id)
    {
        var game = await GetCollection().AsQueryable()
            .FirstOrDefaultAsync(w => w.Id.Equals(id));
        return game;
    }
    
    public async Task<Game> GetGameBySlug(string slug)
    {
        var game = await GetCollection().AsQueryable()
            .FirstOrDefaultAsync(g => g.Slug.Equals(slug));
        return game;
    }
    
    private IMongoCollection<Game> GetCollection()
    {
        var database = _mongoClient.GetDatabase("kumibot");
        var collection = database.GetCollection<Game>("games");
        return collection;
    }
}