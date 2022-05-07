using Kumibot.App.Clients;
using Kumibot.App.Models;
using Kumibot.App.Models.SportRadar;

namespace Kumibot.App.Repositories;

public class SportRadarRepository
{
    /// Cache time in minutes
    private const int CacheTime = 1440;
    
    private static readonly IDictionary<string, CachedObject> _cache = new Dictionary<string, CachedObject>();

    private readonly SportRadarClient _client;
    
    public SportRadarRepository(SportRadarClient client)
    {
        _client = client;
    }

    #region MMA v2
    
    public async Task<Champions.Root> GetChampions()
    {
        return await Get<Champions, Champions.Root>(_client.GetChampions());
    }
    
    public async Task<Competitions.Root> GetCompetitions()
    {
        return await Get<Competitions, Competitions.Root>(_client.GetCompetitions());
    }
    
    public async Task<Seasons.Root> GetSeasons()
    {
        return await Get<Seasons, Seasons.Root>(_client.GetSeasons());
    }
    
    #endregion

    private static async Task<TRoot> Get<T, TRoot>(Task<TRoot> task) where TRoot : class
    {
        const string TypeName = nameof(T);
        
        // Valid cache
        // Returns cached data
        if (_cache.ContainsKey(TypeName) &&
            _cache[TypeName].CachedAt < DateTime.Now.AddMinutes(CacheTime))
        {
            return _cache[TypeName].Data as TRoot;
        }
        
        var data = await task;
        
        // Invalid cache w/ API response
        // Refreshes the cache
        if (data != null)
        {
            _cache[TypeName] = new CachedObject(data);
            return _cache[TypeName].Data as TRoot;
        }
        
        // Invalid cache w/ no API response
        // Try to use cached data if it's there, else this is a first pull that failed and we're out of luck
        return _cache.ContainsKey(TypeName)
            ? _cache[TypeName].Data as TRoot
            : null;
    }
}