using Kumibot.Database.Models.Betting;
using MongoDB.Driver;

namespace Kumibot.Database.Repositories.Betting;

public class WalletRepository : BaseRepository<Wallet>
{
    private readonly IMongoClient _mongoClient;
    public WalletRepository(IMongoClient mongoClient) : base(mongoClient)
    {
        _mongoClient = mongoClient;
        CollectionName = "wallets";
    }
}