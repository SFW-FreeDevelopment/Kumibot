﻿using Kumibot.App.Clients;
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
        if (_cache.ContainsKey(nameof(Champions)) &&
            _cache[nameof(Champions)].CachedAt < DateTime.Now.AddMinutes(CacheTime))
        {
            return _cache[nameof(Champions)].Data as Champions.Root;
        }
        else
        {
            var data = await _client.GetChampions();
            _cache[nameof(Champions)] = new CachedObject(data);
            return _cache[nameof(Champions)].Data as Champions.Root;
        }
    }
}