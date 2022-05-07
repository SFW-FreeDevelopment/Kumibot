using System.Text;
using Discord.Commands;
using Kumibot.App.Repositories;

namespace Kumibot.App.Commands;

public class FightsCommand : CommandBase
{
    private readonly SportRadarRepository _repository;

    public FightsCommand(SportRadarRepository repository)
    {
        _repository = repository;
    }

    [Command("fights")]
    public async Task HandleCommandAsync()
    {
        var root = await _repository.GetSeasons();
        var seasons = root?.Seasons?.OrderBy(s => DateTime.Parse(s.StartDate)).GroupBy(s => s.StartDate)
            .Select(sg => sg.FirstOrDefault())
            .Where(s => s?.StartDate != null && DateTime.Parse(s.StartDate) > DateTime.Now);

        var textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
        var sb = new StringBuilder();
        if (seasons != null)
            foreach (var season in seasons)
            {
                sb.Append(
                    $"- {DateTime.Parse(season.StartDate).ToString("D").Replace("Saturday, ", string.Empty)} | {season.Name}\n");
            }

        await ReplyAsync($"**Fights List**:\n{sb}");
    }
}