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
    
    public async Task<IEnumerable<Wallet>> GetAllWallets()
    {
        var wallets = await GetCollection().AsQueryable().ToListAsync();
        return wallets;
    }
    
    public async Task<Wallet> GetWalletById(Guid id)
    {
        var wallet = await GetCollection().AsQueryable()
            .FirstOrDefaultAsync(w => w.Id.Equals(id));
        return wallet;
    }
    
    public async Task<Wallet> GetWalletByOwner(ulong owner)
    {
        var wallet = await GetCollection().AsQueryable()
            .FirstOrDefaultAsync(w => w.Owner.Equals(owner));
        return wallet;
    }

    public async Task<Wallet> CreateWallet(Wallet data)
    {
        data.Id = Guid.NewGuid();
        data.Version = 1;
        data.CreatedAt = DateTime.UtcNow;
        data.UpdatedAt = data.CreatedAt;
        await GetCollection().InsertOneAsync(data);
        var gameList = await GetCollection().AsQueryable().ToListAsync();
        return gameList.FirstOrDefault(x => x.Id.Equals(data.Id));
    }
    
    public async Task<Wallet> UpdateWallet(Guid id, Wallet data)
    {
        data.UpdatedAt = DateTime.UtcNow;
        data.Version++;
        await GetCollection().ReplaceOneAsync(x => x.Id == id, data);
        return data;
    }
    
    private IMongoCollection<Wallet> GetCollection()
    {
        var database = _mongoClient.GetDatabase("kumibot");
        var collection = database.GetCollection<Wallet>("wallets");
        return collection;
    }
}