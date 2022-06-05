using Kumibot.Database.Models.Combat;
using MongoDB.Driver;

namespace Kumibot.Database.Repositories.Combat;

public class CombatEventRepository : BaseRepository<CombatEvent>
{
    private readonly IMongoClient _mongoClient;

    public CombatEventRepository(IMongoClient mongoClient) : base(mongoClient)
    {
        _mongoClient = mongoClient;
        CollectionName = "combatevents";
    }
}