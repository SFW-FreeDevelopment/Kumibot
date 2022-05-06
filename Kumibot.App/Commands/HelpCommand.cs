using Discord.Commands;

namespace Kumibot.App.Commands;

public class HelpCommand : CommandBase
{
    [Command("help")]
    public async Task HandleCommandAsync()
    {
        await ReplyAsync(Constants.HelpMessage);
    }
}