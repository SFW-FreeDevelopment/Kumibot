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
    
    public async Task<Game> GetGameById(Guid id)
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
    
    public async Task<Game> CreateGame(Game data)
    {
        data.Id = Guid.NewGuid();
        data.Version = 1;
        data.CreatedAt = DateTime.UtcNow;
        data.UpdatedAt = data.CreatedAt;
        await GetCollection().InsertOneAsync(data);
        var gameList = await GetCollection().AsQueryable().ToListAsync();
        return gameList.FirstOrDefault(x => x.Id.Equals(data.Id));
    }
    
    public async Task<Game> UpdateGame(Guid id, Game data)
    {
        data.UpdatedAt = DateTime.UtcNow;
        data.Version++;
        await GetCollection().ReplaceOneAsync(x => x.Id == id, data);
        return data;
    }
    
    private IMongoCollection<Game> GetCollection()
    {
        var database = _mongoClient.GetDatabase("kumibot");
        var collection = database.GetCollection<Game>("games");
        return collection;
    }
}