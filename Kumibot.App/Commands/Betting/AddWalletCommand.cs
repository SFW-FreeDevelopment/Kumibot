using Discord.Commands;
using Kumibot.Database.Models.Betting;
using Kumibot.Database.Repositories;

namespace Kumibot.App.Commands.Betting;

public class AddWalletCommand : CommandBase
{
    private readonly WalletRepository _walletRepository;

    public AddWalletCommand(WalletRepository gameRepository)
    {
        _walletRepository = gameRepository;
    }
    
    [Command("addwallet")]
    public async Task HandleCommandAsync()
    {
        var walletToCreate = new Wallet { Owner = GuildUser.Id, Dollars = 100000.00};
        var wallet = await _walletRepository.CreateWallet(walletToCreate);
        await ReplyAsync($"New wallet added for <@{wallet.Owner}>");
    }
}