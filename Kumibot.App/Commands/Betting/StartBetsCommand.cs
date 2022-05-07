using Discord.Commands;
using Kumibot.App.Models.Betting;
using Kumibot.App.Repositories;
using Kumibot.App.Services;

namespace Kumibot.App.Commands.Betting;

public class StartBetsCommand : CommandBase
{
    private readonly SportsDataIORepository _sportsDataIoRepository;
    private readonly BettingService _bettingService;
    
    public StartBetsCommand(SportsDataIORepository sportsDataIoRepository, BettingService bettingService)
    {
        _sportsDataIoRepository = sportsDataIoRepository;
        _bettingService = bettingService;
    }
    
    [Command("startbets")]
    public async Task HandleCommandAsync([Remainder] string args)
    {
        if (args is "current")
        {
            var events = await _sportsDataIoRepository.GetEvents();
            var currentEvent = events.FirstOrDefault(e => e.Day.Date.Equals(DateTime.Now.Date));
            if (currentEvent is null)
            {
                await ReplyAsync("There is no event today. If you need an event, please create a custom event.");
            }
            else
            {
                await ReplyAsync($"Betting started for {currentEvent.Name}");
            }
        }
    }
}