using Kumibot.App.Clients;
using Kumibot.App.Models;
using Kumibot.App.Models.SportsDataIO;

namespace Kumibot.App.Repositories;

public class SportsDataIORepository
{
    /// Cache time in minutes
    private const int CacheTime = 1440;
    
    private static readonly IDictionary<string, CachedObject> _cache = new Dictionary<string, CachedObject>();

    private readonly SportsDataIOClient _client;
    
    public SportsDataIORepository(SportsDataIOClient client)
    {
        _client = client;
    }
    
    public async Task<List<Event>> GetEvents()
    {
        return await Get(_client.GetEvents());
    }
    
    private static async Task<T> Get<T>(Task<T> task) where T : class
    {
        const string TypeName = nameof(T);
        
        // Valid cache
        // Returns cached data
        if (_cache.ContainsKey(TypeName) &&
            _cache[TypeName].CachedAt < DateTime.Now.AddMinutes(CacheTime))
        {
            return _cache[TypeName].Data as T;
        }
        
        var data = await task;
        
        // Invalid cache w/ API response
        // Refreshes the cache
        if (data != null)
        {
            _cache[TypeName] = new CachedObject(data);
            return _cache[TypeName].Data as T;
        }
        
        // Invalid cache w/ no API response
        // Try to use cached data if it's there, else this is a first pull that failed and we're out of luck
        return _cache.ContainsKey(TypeName)
            ? _cache[TypeName].Data as T
            : null;
    }
}