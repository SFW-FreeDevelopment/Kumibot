using Kumibot.Database.Interfaces;
using Kumibot.Database.Models.Betting;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Kumibot.Database.Repositories;

public class WalletRepository : BaseRepository<Wallet>
{
    private readonly IMongoClient _mongoClient;
    public WalletRepository(IMongoClient mongoClient) : base(mongoClient)
    {
        _mongoClient = mongoClient;
        CollectionName = "wallets";
    }
}