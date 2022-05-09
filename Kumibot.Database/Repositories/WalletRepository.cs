using Kumibot.Database.Models.Betting;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Kumibot.Database.Repositories;

public class WalletRepository
{
    private readonly IMongoClient _mongoClient;

    public WalletRepository(IMongoClient mongoClient)
    {
        _mongoClient = mongoClient;
    }
    
    public async Task<IEnumerable<Wallet>> GetAllGames()
    {
        var wallets = await GetCollection().AsQueryable().ToListAsync();
        return wallets;
    }
    
    public async Task<Wallet> GetGameById(int id)
    {
        var wallet = await GetCollection().AsQueryable()
            .FirstOrDefaultAsync(w => w.Id.Equals(id));
        return wallet;
    }
    
    public async Task<Wallet> GetBettingEventByOwner(ulong owner)
    {
        var wallet = await GetCollection().AsQueryable()
            .FirstOrDefaultAsync(w => w.Owner.Equals(owner));
        return wallet;
    }
    
    private IMongoCollection<Wallet> GetCollection()
    {
        var database = _mongoClient.GetDatabase("kumibot");
        var collection = database.GetCollection<Wallet>("wallets");
        return collection;
    }
}