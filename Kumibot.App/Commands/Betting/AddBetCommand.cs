using Discord.Commands;
using Kumibot.App.Clients;
using Kumibot.App.Models.Betting;
using Kumibot.App.Repositories;
using Kumibot.App.Services;

namespace Kumibot.App.Commands.Betting;

public class AddBetCommand : CommandBase
{
    private readonly SportsDataIORepository _sportsDataIoRepository;
    private readonly SportsDataIOClient _sportsDataIoClient;
    private readonly BettingService _bettingService;

    public AddBetCommand(SportsDataIORepository sportsDataIoRepository, BettingService bettingService, SportsDataIOClient sportsDataIoClient)
    {
        _sportsDataIoRepository = sportsDataIoRepository;
        _bettingService = bettingService;
        _sportsDataIoClient = sportsDataIoClient;
    }

    [Command("addbet")]
    public async Task HandleCommandAsync([Remainder] string args)
    {
        var splitArgs = args.Split(" ");
        if (splitArgs.Length < 3) await ReplyAsync("No money value supplied.");
        var valueConverted = double.TryParse(splitArgs[2], out var betMoney);
        if (!valueConverted) await ReplyAsync("Could not convert money value.");
        var bet = new Bet
        {
            Owner = GuildUser.Id,
            DollarAmount = betMoney,
            Fighter = splitArgs[1]
        };
        var betAdded = _bettingService.AddBet(splitArgs[0], bet);
        if (betAdded) await ReplyAsync($"Bet added for @<{bet.Owner}>.");
        else await ReplyAsync($"Bet could not be added.");
    }
}