using Discord;
using Discord.Interactions;
using Kumibot.Database.Repositories.Betting;

namespace Kumibot.App.Interactions.Components.SelectLists.Responses;

public class ProcessMatchUpResultsEventSelectListResponse : InteractionBase
{
    private readonly BettingEventRepository _bettingEventRepository;

    public ProcessMatchUpResultsEventSelectListResponse(BettingEventRepository bettingEventRepository)
    {
        _bettingEventRepository = bettingEventRepository;
    }
    // TODO: Add response for match up select list
    [ComponentInteraction("process_match_up_results_event_select_list")]
    public async Task ComponentResponse()
    {
        var interaction = (IComponentInteraction)Interaction;
        var bettingEventId = interaction.Data.Values.FirstOrDefault();
        var bettingEvent =
            await _bettingEventRepository.GetById(bettingEventId ?? string.Empty);
        var matchUps = bettingEvent.MatchUps;
        var selectMenuBuilder = new SelectMenuBuilder().WithCustomId("process_match_up_results_match_up_select_list");
        foreach (var matchUp in matchUps.Where(x => !x.Finished))
        {
            selectMenuBuilder.AddOption($"{matchUp.FighterOne.Name} vs {matchUp.FighterTwo.Name}",
                $"{bettingEventId}_{matchUp.Position}");
        }

        var builder = new ComponentBuilder().WithSelectMenu(selectMenuBuilder);
        await RespondAsync("Select the match-up to process:", components: builder.Build());
    }
}