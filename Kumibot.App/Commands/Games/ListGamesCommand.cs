using System.Text;
using System.Text.Json;
using Discord.Commands;
using Kumibot.App.Models.Games;
using Kumibot.App.Repositories;

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
        var games = _gameRepository.GetGames();
        var sb = new StringBuilder();
        if (games != null)
            foreach (var game in games)
            {
                sb.Append($"- {game.Name}\n");
            }

        await ReplyAsync($"**Game List**:\n{sb}");
    }
}