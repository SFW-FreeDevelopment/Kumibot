using Kumibot.App.Clients;
using Kumibot.App.Models;
using Kumibot.App.Models.SportRadar;

namespace Kumibot.App.Repositories;

public class SportRadarRepository
{
    /// Cache time in minutes
    private const int CacheTime = 1440;
    
    private static readonly IDictionary<string, CachedObject> _cache = new Dictionary<string, CachedObject>();

    private readonly SportradarClient _client;
    
    public SportRadarRepository(SportradarClient client)
    {
        _client = client;
    }
    
    public async Task<Champions.Root> GetChampions()
    {
        return await Get<Champions, Champions.Root>(_client.GetChampions());
    }
    
    public async Task<Competitions.Root> GetCompetitions()
    {
        return await Get<Competitions, Competitions.Root>(_client.GetCompetitions());
    }

    private static async Task<TRoot> Get<T, TRoot>(Task<TRoot> getMethod) where TRoot : class
    {
        if (_cache.ContainsKey(nameof(T)) &&
            _cache[nameof(T)].CachedAt < DateTime.Now.AddMinutes(CacheTime))
        {
            return _cache[nameof(T)].Data as TRoot;
        }
        else
        {
            var data = await getMethod;
            if (data == null)
            {
                if (_cache.ContainsKey(nameof(T)))
                {
                    return _cache[nameof(T)].Data as TRoot;
                }
                return null;
            }
            _cache[nameof(T)] = new CachedObject(data);
            return _cache[nameof(T)].Data as TRoot;
        }
    }
}