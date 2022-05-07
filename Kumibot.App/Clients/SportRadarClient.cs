using Kumibot.App.Models.SportRadar;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace Kumibot.App.Clients;

public class SportRadarClient
{
    private const string BaseUrl = "https://api.sportradar.com/mma/trial/v2/en";

    private readonly string _apiKey;
    private readonly RestClient _client;

    public SportRadarClient(IConfiguration configuration)
    {
        _apiKey = configuration["SportRadarApiKey"];
        _client = new RestClient(BaseUrl);
    }

    #region MMA v2

    public async Task<Champions.Root> GetChampions()
    {
        return await Get<Champions.Root>("champions.json");
    }

    public async Task<Competitions.Root> GetCompetitions()
    {
        return await Get<Competitions.Root>("competitions.json");
    }
    
    #endregion
    
    private async Task<TRoot> Get<TRoot>(string route) where TRoot : class
    {
        try
        {
            var request = new RestRequest($"{BaseUrl}/{route}?api_key={_apiKey}");
            var response = await _client.ExecuteAsync<TRoot>(request);
            return response.IsSuccessful ? response.Data : null;
        }
        catch
        {
            return null;
        }
    }
}