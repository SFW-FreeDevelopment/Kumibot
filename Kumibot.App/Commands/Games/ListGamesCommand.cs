using System.Text;
using Discord.Commands;
using Kumibot.Database.Repositories;

namespace Kumibot.App.Commands.Games;

public class ListGamesCommand : CommandBase
{
    private readonly GameRepository _gameRepository;

    public ListGamesCommand(GameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    [Command("listgames")]
    public async Task HandleCommandAsync()
    {
        var games = await _gameRepository.GetAllGames();
        var sb = new StringBuilder();
        if (games != null)
            foreach (var game in games)
            {
                sb.Append($"- {game.Name}\n");
            }

        await ReplyAsync($"**Game List**:\n{sb}");
    }
}