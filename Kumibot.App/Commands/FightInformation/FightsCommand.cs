using System.Text;
using Discord.Commands;
using Kumibot.App.Repositories;

namespace Kumibot.App.Commands.FightInformation;

public class FightsCommand : CommandBase
{
    private readonly SportRadarRepository _repository;
    private readonly SportsDataIORepository _sportsDataIoRepository;

    public FightsCommand(SportRadarRepository repository, SportsDataIORepository sportsDataIoRepository)
    {
        _repository = repository;
        _sportsDataIoRepository = sportsDataIoRepository;
    }

    [Command("fights")]
    public async Task HandleCommandAsync([Remainder] string arg = null)
    {
        // var root = await _repository.GetSeasons();
        // var seasons = root?.Seasons?.OrderBy(s => DateTime.Parse(s.StartDate)).GroupBy(s => s.StartDate)
        //     .Select(sg => sg.FirstOrDefault())
        //     .Where(s => s?.StartDate != null && DateTime.Parse(s.StartDate) > DateTime.Now);

        var events = await _sportsDataIoRepository.GetEvents();
        if (events != null)
        {
            var sb = new StringBuilder();
            switch (arg)
            {
                case "all":
                {
                    foreach (var e in events)
                    {
                        sb.Append(
                            $"- {FormatEventDate(e.Day)} | {e.Name}\n");
                    }

                    break;
                }
                case "next":
                {
                    var nextEvent = events.FirstOrDefault(x => x.Day.Date >= DateTime.Now.Date);
                    sb.Append(
                        $"- {FormatEventDate(nextEvent?.Day)} | {nextEvent?.Name}\n");
                    break;
                }
                default:
                {
                    foreach (var e in events.Where(x => x.Day.Date >= DateTime.Now.Date))
                    {
                        sb.Append(
                            $"- {FormatEventDate(e.Day)} | {e.Name}\n");
                    }

                    break;
                }
            }

            await ReplyAsync($"**Fights List**:\n{sb}");
        }
    }

    #region Private Methods

    private static string FormatEventDate(DateTime? eventDate)
    {
        return eventDate?.ToString("D").Replace("Saturday, ", string.Empty);
    }

    #endregion
}