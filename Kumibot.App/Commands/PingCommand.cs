using Discord.Commands;

namespace Kumibot.App.Commands;

public class PingCommand : CommandBase
{
    [Command("ping")]
    public async Task HandleCommandAsync()
    {
        await ReplyAsync(Constants.PingMessage);
    }
}