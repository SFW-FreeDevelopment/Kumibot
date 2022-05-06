using System.Globalization;
using System.Text;
using Discord.Commands;
using Kumibot.App.Repositories;

namespace Kumibot.App.Commands;

public class ChampionsCommand : CommandBase
{
    private SportRadarRepository _repository;
    
    public ChampionsCommand(SportRadarRepository repository)
    {
        _repository = repository;
    }
    
    [Command("champions")]
    public async Task HandleCommandAsync()
    {
        var root = await _repository.GetChampions();
        var weightClasses = root?.Categories?.FirstOrDefault(c => c.Name.Equals("UFC"))?.WeightClasses;
        var sb = new StringBuilder();
        var cultureInfo   = Thread.CurrentThread.CurrentCulture;  
        var textInfo = cultureInfo.TextInfo;
        if (weightClasses != null)
            foreach (var weightClass in weightClasses)
            {
                sb.Append($"- **{textInfo.ToTitleCase(weightClass.Description)}**: {weightClass.Competitor.Name}\n");
            }

        await ReplyAsync($"**Champion List**:\n{sb}");
    }
}