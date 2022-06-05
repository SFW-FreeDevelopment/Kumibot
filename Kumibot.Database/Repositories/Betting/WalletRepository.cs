using Kumibot.Database.Models.Betting;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Kumibot.Database.Repositories.Betting;

public class WalletRepository : BaseRepository<Wallet>
{
    private readonly IMongoClient _mongoClient;
    public WalletRepository(IMongoClient mongoClient) : base(mongoClient)
    {
        _mongoClient = mongoClient;
        CollectionName = "wallets";
    }
    
    public new async Task<Wallet> GetByDiscordOwner(ulong discordOwner)
    {
        var item = await GetCollection().AsQueryable()
            .FirstOrDefaultAsync(x => x.DiscordOwner.Equals(discordOwner));
        return item;
    }
}