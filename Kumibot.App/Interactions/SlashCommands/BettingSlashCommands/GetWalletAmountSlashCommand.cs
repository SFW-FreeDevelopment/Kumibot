using Discord;
using Discord.Interactions;
using Kumibot.Database.Repositories.Betting;

namespace Kumibot.App.Interactions.SlashCommands.BettingSlashCommands;

public class GetWalletAmountSlashCommand : InteractionBase
{
    private readonly WalletRepository _walletRepository;

    public GetWalletAmountSlashCommand(WalletRepository walletRepository)
    {
        _walletRepository = walletRepository;
    }

    [DefaultMemberPermissions(GuildPermission.UseApplicationCommands)]
    [SlashCommand("getwalletamount", "Gets the current amount of currency the user has in their wallet", ignoreGroupNames: true)]
    public async Task GetWalletAmount()
    {
        var wallet = await _walletRepository.GetByDiscordOwner(User.Id);
        if (wallet is not null)
        {
            await ReplyAsync($"{Mention}'s wallet contains ${Math.Round(wallet.Dollars, 2, MidpointRounding.ToZero)}");
        }
        else
        {
            await ReplyAsync($"No wallet exists for user {Mention}");
        }
    }
}