using Discord;
using Discord.Interactions;
using Kumibot.Database.Models.Betting;
using Kumibot.Database.Repositories;

namespace Kumibot.App.Interactions.SlashCommands.BettingSlashCommands;

public class AddWalletSlashCommand : InteractionBase
{
    private readonly WalletRepository _walletRepository;

    public AddWalletSlashCommand(WalletRepository walletRepository)
    {
        _walletRepository = walletRepository;
    }

    [DefaultMemberPermissions(GuildPermission.UseApplicationCommands)]
    [SlashCommand("addwallet", "Adds a wallet to track user's currency amount for betting", ignoreGroupNames: true)]
    public async Task AddWallet()
    {
        var wallet = await _walletRepository.GetByDiscordOwner(User.Id);
        if (wallet is not null)
        {
            await ReplyAsync($"Wallet exists for user {Mention}");
        }
        else
        { 
            wallet = await _walletRepository.Create(new Wallet
            {
                DiscordOwner = User.Id,
                Dollars = 100000
            });
            if (wallet is null)
            {
                await ReplyAsync($"Could not create wallet for user {Mention}");
            }
            else
            {
                await ReplyAsync($"Wallet created for user {Mention}");
            }
        }
    }
}