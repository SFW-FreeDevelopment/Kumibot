using System.Text;
using Discord.Commands;
using Kumibot.App.Repositories;

namespace Kumibot.App.Commands.FightInformation;

public class ChampionsCommand : CommandBase
{
    private readonly SportRadarRepository _repository;
    
    public ChampionsCommand(SportRadarRepository repository)
    {
        _repository = repository;
    }
    
    [Command("champions")]
    public async Task HandleCommandAsync()
    {
        var root = await _repository.GetChampions();
        var weightClasses = root?.Categories?.FirstOrDefault(c => c.Name.Equals("UFC"))?.WeightClasses;
        
        var textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
        var sb = new StringBuilder();
        if (weightClasses != null)
            foreach (var weightClass in weightClasses)
            {
                sb.Append($"- {textInfo.ToTitleCase(weightClass.Description)}: {weightClass.Competitor.Name}\n");
            }

        await ReplyAsync($"**Champion List**:\n{sb}");
    }
}