using Microsoft.Extensions.Configuration;
using RestSharp;

namespace Kumibot.App.Clients;

public class SportsDataIOClient
{
    private readonly string _apiKey, _baseUrl;
    private readonly RestClient _client;

    public SportsDataIOClient(IConfiguration configuration)
    {
        _apiKey = configuration["SportDataIOApiKey"];
        _baseUrl = configuration["SportDataIOBaseUrl"];
        _client = new RestClient(_baseUrl);
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