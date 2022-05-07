using System.Text;
using Discord.Commands;
using Kumibot.App.Repositories;

namespace Kumibot.App.Commands;

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
    public async Task HandleCommandAsync()
    {
        // var root = await _repository.GetSeasons();
        // var seasons = root?.Seasons?.OrderBy(s => DateTime.Parse(s.StartDate)).GroupBy(s => s.StartDate)
        //     .Select(sg => sg.FirstOrDefault())
        //     .Where(s => s?.StartDate != null && DateTime.Parse(s.StartDate) > DateTime.Now);

        var events = await _sportsDataIoRepository.GetEvents();
        
        var sb = new StringBuilder();
        if (events != null)
            foreach (var e in events)
            {
                sb.Append(
                    $"- {e.Day.ToString("D").Replace("Saturday, ", string.Empty)} | {e.Name}\n");
            }

        await ReplyAsync($"**Fights List**:\n{sb}");
    }
}