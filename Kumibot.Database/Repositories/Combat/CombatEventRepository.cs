using Kumibot.Database.Interfaces;
using Kumibot.Database.Models.CombatEvent;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Kumibot.Database.Repositories;

public class CombatEventRepository : BaseRepository<CombatEvent>
{
    private readonly IMongoClient _mongoClient;

    public CombatEventRepository(IMongoClient mongoClient) : base(mongoClient)
    {
        _mongoClient = mongoClient;
        CollectionName = "combatevents";
    }
}