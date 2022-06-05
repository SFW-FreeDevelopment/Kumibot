using Kumibot.Database.Models.Betting;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Kumibot.Database.Repositories.Betting;

public class WalletRepository : BaseRepository<Wallet>
{
    public WalletRepository(IMongoClient mongoClient) : base(mongoClient) { CollectionName = "wallets"; }
    
    public new async Task<Wallet> GetByDiscordOwner(ulong discordOwner)
    {
        var item = await GetCollection().AsQueryable()
            .FirstOrDefaultAsync(x => x.DiscordOwner.Equals(discordOwner));
        return item;
    }
}