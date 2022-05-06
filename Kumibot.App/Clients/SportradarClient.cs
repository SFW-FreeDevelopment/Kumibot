using Kumibot.App.Models.SportRadar;
using RestSharp;

namespace Kumibot.App.Clients;

public class SportradarClient
{
    private readonly RestClient _client;
    private const string BaseUrl = "https://api.sportradar.com/mma/trial/v2/en";
    private const string ApiKey = "CHANGE_ME";
    public SportradarClient()
    {
        _client = new RestClient(BaseUrl);
    }

    #region MMA v2

    public async Task<Champions.Root> GetChampions()
    {
        var request = new RestRequest($"{BaseUrl}/champions.json?api_key={ApiKey}");
    }
    
    public async Task GetCompetitions()
    {
        throw new NotImplementedException();
    }

    #endregion
}