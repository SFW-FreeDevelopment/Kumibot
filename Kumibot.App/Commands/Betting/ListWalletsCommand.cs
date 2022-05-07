using Discord.Commands;
using Kumibot.App.Repositories;

namespace Kumibot.App.Commands.Betting;

public class CheckWalletCommand : CommandBase
{
    private readonly WalletRepository _walletRepository;

    public CheckWalletCommand(WalletRepository walletRepository)
    {
        _walletRepository = walletRepository;
    }

    [Command("checkwallet")]
    public async Task HandleCommandAsync()
    {
        var walletOwner = GuildUser.Id;
        var wallet = _walletRepository.GetWalletByOwner(walletOwner);
        if (wallet != null)
        {
            var formattedDollars = wallet.Dollars.ToString("0.00");
            await ReplyAsync($"Owner: <@{wallet.Owner}>\nFunds: {formattedDollars}");
            
        }
        else
        {
            await ReplyAsync($"No wallet exists for <@{walletOwner}>");
        }
    }
}