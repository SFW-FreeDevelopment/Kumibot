using System.Text;
using Discord.Commands;
using Kumibot.App.Repositories;

namespace Kumibot.App.Commands;

public class CompetitionsCommand : CommandBase
{
    private readonly SportRadarRepository _repository;
    
    public CompetitionsCommand(SportRadarRepository repository)
    {
        _repository = repository;
    }
    
    [Command("competitions")]
    public async Task HandleCommandAsync()
    {
        var root = await _repository.GetCompetitions();
        var competitions = root?.Competitions;
        
        var textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
        var sb = new StringBuilder();
        if (competitions != null)
            foreach (var competition in competitions)
            {
                sb.Append($"- **{textInfo.ToTitleCase(competition.Name)}**: {competition.Type}\n");
            }

        await ReplyAsync($"**Competitions List**:\n{sb}");
    }
}