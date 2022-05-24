using Discord;
using Discord.Interactions;
using Kumibot.Database.Repositories;

namespace Kumibot.App.Interactions.MessageComponents.Responses;

public class ProcessMatchUpResultsEventSelectList : InteractionBase
{
    private readonly BettingEventRepository _bettingEventRepository;

    public ProcessMatchUpResultsEventSelectList(BettingEventRepository bettingEventRepository)
    {
        _bettingEventRepository = bettingEventRepository;
    }
    
    [ComponentInteraction("process_match_up_results_event_select_list")]
    public async Task ComponentResponse()
    {
        var interaction = (IComponentInteraction)Interaction;
        var bettingEventId = interaction.Data.Values.FirstOrDefault();
        var bettingEvent =
            await _bettingEventRepository.GetBettingEventById(bettingEventId ?? string.Empty);
        var matchUps = bettingEvent.MatchUps;
        var selectMenuBuilder = new SelectMenuBuilder().WithCustomId("process_match_up_results_match_up_select_list");
        foreach (var matchUp in matchUps)
        {
            selectMenuBuilder.AddOption($"{matchUp.FighterOne} vs {matchUp.FighterTwo}",
                $"{bettingEventId}_{matchUp.Position}");
        }

        var builder = new ComponentBuilder().WithSelectMenu(selectMenuBuilder);
        await RespondAsync("Select the match-up to process:", components: builder.Build());
    }
}