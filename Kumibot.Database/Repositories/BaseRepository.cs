using Kumibot.Database.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Kumibot.Database.Repositories;

public abstract class BaseRepository<T> where T : BaseResource
{
    private readonly IMongoClient _mongoClient;
    protected string CollectionName;

    protected BaseRepository(IMongoClient mongoClient)
    {
        _mongoClient = mongoClient;
    }

    public virtual async Task<List<T>> GetAll()
    {
        var items = await GetCollection().AsQueryable().ToListAsync();
        return items;
    }

    public virtual async Task<T> GetById(string id)
    {
        var item = await GetCollection().AsQueryable()
            .FirstOrDefaultAsync(w => w.Id.Equals(id));
        return item;
    }
    
    public virtual async Task<List<T>> GetByDiscordOwner(ulong discordOwner)
    {
        var items = await GetCollection().AsQueryable()
            .Where(w => w.DiscordOwner.Equals(discordOwner)).ToListAsync();
        return items;
    }

    public virtual async Task<T> Create(T data)
    {
        data.Id = Guid.NewGuid().ToString();
        data.Version = 1;
        data.CreatedAt = DateTime.UtcNow;
        data.UpdatedAt = data.CreatedAt;
        await GetCollection().InsertOneAsync(data);
        var items = await GetCollection().AsQueryable().ToListAsync();
        return items.FirstOrDefault(x => x.Id.Equals(data.Id));
    }

    public virtual async Task<T> Update(string id, T data)
    {
        data.UpdatedAt = DateTime.UtcNow;
        data.Version++;
        await GetCollection().ReplaceOneAsync(x => x.Id.Equals(id), data);
        return data;
    }

    public virtual Task Delete(string id)
    {
        throw new NotImplementedException();
    }

    protected IMongoCollection<T> GetCollection()
    {
        var database = _mongoClient.GetDatabase("kumibot");
        var collection = database.GetCollection<T>(CollectionName);
        return collection;
    }
}