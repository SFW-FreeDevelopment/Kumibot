using System.Text.Json;
using Kumibot.App.Models.Games;

namespace Kumibot.App.Repositories;

public class GameRepository
{
    private readonly List<Game> _games;
    private readonly StreamReader _gamesStream;
    private readonly string _sFile;
    
    public GameRepository()
    {
        var sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;            
        _sFile = Path.Combine(sCurrentDirectory, @"..\..\..\Data\games.json");
        _gamesStream = new StreamReader(Path.GetFullPath(_sFile));
        _games = JsonSerializer.Deserialize<List<Game>>(_gamesStream.ReadToEnd());
        _gamesStream.Close();
    }

    public List<Game> GetGames()
    {
        return _games;
    }
    
    public Game GetGameBySlug(string slug)
    {
        return _games.FirstOrDefault(g => g.Slug.Equals(slug));
    }
    
    public Game AddGame(Game game)
    {
        _games.Add(game);
        File.WriteAllText(_sFile, JsonSerializer.Serialize(_games));
        return _games.FirstOrDefault(g => g.Slug.Equals(game.Slug));
    }
}