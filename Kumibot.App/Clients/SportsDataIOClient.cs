using Kumibot.App.Models.SportsDataIO;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace Kumibot.App.Clients;

public class SportsDataIOClient
{
    private readonly string _apiKey, _baseUrl;
    private readonly RestClient _client;

    public SportsDataIOClient(IConfiguration configuration)
    {
        _apiKey = configuration["SportsDataIOApiKey"];
        _baseUrl = configuration["SportsDataIOBaseUrl"];
        _client = new RestClient(_baseUrl);
    }
    
    public async Task<List<Event>> GetEvents()
    {
        return await Get<List<Event>>($"scores/json/Schedule/UFC/{DateTime.Now.Year}");
    }
    
    private async Task<TRoot> Get<TRoot>(string route) where TRoot : class
    {
        try
        {
            var request = new RestRequest($"{_baseUrl}/{route}?key={_apiKey}");
            var response = await _client.ExecuteAsync<TRoot>(request);
            return response.IsSuccessful ? response.Data : null;
        }
        catch
        {
            return null;
        }
    }
}