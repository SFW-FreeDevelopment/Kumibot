using System.Text;
using System.Text.Json;
using Discord.Commands;
using Kumibot.App.Commands;
using Kumibot.App.Models.Games;
using Kumibot.App.Repositories;

public class AddGamesCommand : CommandBase
{
    private readonly GameRepository _gameRepository;

    public AddGamesCommand(GameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }
    
    [Command("addgame")]
    public async Task HandleCommandAsync([Remainder] string remainder)
    {
        var commandArgs = remainder.Split(" ");
        var sb = new StringBuilder();
        for (var i = 1; i < commandArgs.Length; i++)
        {
            sb.Append($"{commandArgs[i]} ");
        }

        var gameToCreate = new Game { Slug = commandArgs[0], Name = sb.ToString() };
        var game = _gameRepository.AddGame(gameToCreate);
        await ReplyAsync($"New game added: {game.Slug} - {game.Name}");
    }
}