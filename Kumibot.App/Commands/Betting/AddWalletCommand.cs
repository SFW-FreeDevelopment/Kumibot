using Discord.Commands;
using Kumibot.Database.Models.Betting;
using Kumibot.Database.Repositories;
using Kumibot.Database.Repositories.Betting;

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
        var walletToCreate = new Wallet { DiscordOwner = GuildUser.Id, Dollars = 100000.00};
        var wallet = await _walletRepository.Create(walletToCreate);
        await ReplyAsync($"New wallet added for <@{wallet.DiscordOwner}>");
    }
}