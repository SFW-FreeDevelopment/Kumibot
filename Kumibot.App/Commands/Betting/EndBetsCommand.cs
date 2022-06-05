using Discord.Commands;
using Kumibot.App.Clients;
using Kumibot.App.Repositories;
using Kumibot.App.Services;
using Kumibot.Database.Repositories;
using Kumibot.Database.Repositories.Betting;

namespace Kumibot.App.Commands.Betting;

public class EndBetsCommand : CommandBase
{
    private readonly SportsDataIORepository _sportsDataIoRepository;
    private readonly SportsDataIOClient _sportsDataIoClient;
    private readonly BettingService _bettingService;
    private readonly WalletRepository _walletRepository;

    public EndBetsCommand(SportsDataIORepository sportsDataIoRepository, BettingService bettingService, SportsDataIOClient sportsDataIoClient, WalletRepository walletRepository)
    {
        _sportsDataIoRepository = sportsDataIoRepository;
        _bettingService = bettingService;
        _sportsDataIoClient = sportsDataIoClient;
        _walletRepository = walletRepository;
    }

    [Command("endmatch")]
    public async Task HandleCommandAsync([Remainder] string args)
    {
        // var splitArgs = args.Split(" ");
        // if (splitArgs.Length < 3)
        // {
        //     await ReplyAsync("Not enough arguments");
        // }
        // else
        // {
        //     if (splitArgs[0] is "current")
        //     {
        //         var events = await _sportsDataIoRepository.GetEvents();
        //         //var currentEvent = events.FirstOrDefault(e => e.Day.Date.Equals(DateTime.Now.Date));
        //         var currentEvent = events.FirstOrDefault(e => e.EventId.Equals(239));
        //         if (currentEvent is null)
        //         {
        //             await ReplyAsync("There is no event today. If you need an event, please create a custom event.");
        //         }
        //         else
        //         {
        //             var validPosition = int.TryParse(splitArgs[1], out var position);
        //             if (!validPosition) await ReplyAsync("Not a valid match-up position");
        //             var matchUp = _bettingService.GetMatchUps(currentEvent.Name).FirstOrDefault(mu => mu.Position.Equals(position));
        //             if (matchUp is null)
        //             {
        //                 await ReplyAsync("Match-up doesn't exist");
        //             }
        //             else
        //             {
        //                 var validWinnerId = long.TryParse(splitArgs[2], out var winnerId);
        //                 var winnerSet = _bettingService.SetWinner(currentEvent.Name, position, winnerId);
        //                 if (winnerSet)
        //                 {
        //                     var bets = _bettingService.GetBets(currentEvent.Name);
        //                     foreach (var bet in bets.Where(b => !b.Processed && b.FighterId.Equals(matchUp.FighterOneId) | b.FighterId.Equals(matchUp.FighterTwoId)))
        //                     {
        //                         if (bet.FighterId.Equals(winnerId))
        //                         {
        //                             var earnings = bet.DollarAmount * 3;
        //                             var wallet = _walletRepository.UpdateWalletAmount(bet.Owner, earnings);
        //                             if (wallet is null)
        //                             {
        //                                 await ReplyAsync("Wallet could not be updated");
        //                             }
        //                             else
        //                             {
        //                                 await ReplyAsync($"Congratulations, <@{bet.Owner}>! You earned ${earnings.ToString("0.00")}");
        //                             }
        //                         }
        //                         else
        //                         {
        //                             var losses = -bet.DollarAmount;
        //                             var wallet = _walletRepository.UpdateWalletAmount(bet.Owner, losses);
        //                             if (wallet is null)
        //                             {
        //                                 await ReplyAsync("Wallet could not be updated");
        //                             }
        //                             else
        //                             {
        //                                 await ReplyAsync($"Sorry, @<{bet.Owner}>. You lost ${bet.DollarAmount.ToString("0.00")}");
        //                             }
        //                         }
        //                     }
        //                 }
        //                 else
        //                 {
        //                     await ReplyAsync("Could not set winner");
        //                 }
        //             }
        //         }
        //     }
        // }
    }
}