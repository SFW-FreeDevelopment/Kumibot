using System.Text;
using Discord.Commands;
using Kumibot.Database.Models.Games;
using Kumibot.Database.Repositories;

namespace Kumibot.App.Commands.Games;

public class AddGameCommand : CommandBase
{
    private readonly GameRepository _gameRepository;

    public AddGameCommand(GameRepository gameRepository)
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

        var gameToCreate = new Game { Slug = commandArgs[0], Name = sb.ToString().Trim() };
        var game = await _gameRepository.CreateGame(gameToCreate);
        await ReplyAsync($"New game added: {game.Slug} - {game.Name}");
    }
}