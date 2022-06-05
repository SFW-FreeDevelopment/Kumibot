using Kumibot.Database.Models.Combat;
using MongoDB.Driver;

namespace Kumibot.Database.Repositories.Combat;

public class CombatEventRepository : BaseRepository<CombatEvent>
{
    public CombatEventRepository(IMongoClient mongoClient) : base(mongoClient) { CollectionName = "combatevents"; }
}