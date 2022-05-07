using System.Text;
using Discord.Commands;
using Kumibot.App.Clients;
using Kumibot.App.Models.Betting;
using Kumibot.App.Models.SportsDataIO;
using Kumibot.App.Repositories;
using Kumibot.App.Services;

namespace Kumibot.App.Commands.Betting;

public class StartBetsCommand : CommandBase
{
    private readonly SportsDataIORepository _sportsDataIoRepository;
    private readonly SportsDataIOClient _sportsDataIoClient;
    private readonly BettingService _bettingService;

    public StartBetsCommand(SportsDataIORepository sportsDataIoRepository, BettingService bettingService, SportsDataIOClient sportsDataIoClient)
    {
        _sportsDataIoRepository = sportsDataIoRepository;
        _bettingService = bettingService;
        _sportsDataIoClient = sportsDataIoClient;
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
                var detailedEvent = await _sportsDataIoClient.GetEvent(currentEvent.EventId);
                var matchUps = GetMatchUpsFromDetailedEventFights(detailedEvent?.Fights).ToList();
                var eventStarted = _bettingService.StartEvent(new BettingEvent
                {
                    EventTitle = currentEvent.Name,
                    MatchUps = matchUps
                });
                if (eventStarted)
                {
                    var sb = new StringBuilder($"Betting started for **{currentEvent.Name}**\n\n");
                    var matchUpCount = matchUps.Count;
                    if (matchUpCount >= 1)
                    {
                        for (var i = 0; i < 5; i++)
                        {
                            if (i is 0) sb.Append("**Main Card**\n");
                            sb.Append($"- {matchUps[i].FighterOne} vs {matchUps[i].FighterTwo}\n");
                        }
                    }
                    if (matchUpCount > 5)
                    {
                        for (var i = 5; i < 10; i++)
                        {
                            if (i is 5) sb.Append("\n**Prelims**\n");
                            sb.Append($"- {matchUps[i].FighterOne} vs {matchUps[i].FighterTwo}\n");
                        }
                    }
                    if (matchUpCount > 10)
                    {
                        for (var i = 10; i < 15; i++)
                        {
                            if (i is 10) sb.Append("\n**Early Prelims**\n");
                            sb.Append($"- {matchUps[i].FighterOne} vs {matchUps[i].FighterTwo}\n");
                        }
                    }
                    await ReplyAsync(sb.ToString());
                }
                else
                {
                    await ReplyAsync("Event could not be started.");
                }
            }
        }
    }

    #region Private Methods

    private static IEnumerable<MatchUp> GetMatchUpsFromDetailedEventFights(List<Fight> fights)
    {
        return fights is null
            ? new List<MatchUp>()
            : fights.Select(fight => fight.Fighters).Select(fighters => new MatchUp
            {
                FighterOne = $"{fighters[0].FirstName} {fighters[0].LastName}",
                FighterTwo = $"{fighters[1].FirstName} {fighters[1].LastName}"
            });
    }

    #endregion
}