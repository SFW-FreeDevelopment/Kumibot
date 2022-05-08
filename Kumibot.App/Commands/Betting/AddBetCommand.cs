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
        var validId = long.TryParse(splitArgs[1], out var fighterId);
        if (!validId)
        {
            await ReplyAsync("Not a valid Id");
        }
        else
        {
            if (splitArgs[0] is "current")
            {
                var events = await _sportsDataIoRepository.GetEvents();
                //var currentEvent = events.FirstOrDefault(e => e.Day.Date.Equals(DateTime.Now.Date));
                var currentEvent = events.FirstOrDefault(e => e.EventId.Equals(239));
                if (currentEvent is null)
                {
                    await ReplyAsync("There is no event today. If you need an event, please create a custom event.");
                }
                else
                {
                    var bet = new Bet
                    {
                        Owner = GuildUser.Id,
                        DollarAmount = betMoney,
                        FighterId = fighterId
                    };
                    var betAdded = _bettingService.AddBet(currentEvent.Name, bet);
                    if (betAdded) await ReplyAsync($"Bet added for <@{bet.Owner}>.");
                    else await ReplyAsync("Bet could not be added.");
                }
            }
        }
    }
}