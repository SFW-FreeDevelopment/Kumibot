using Discord;
using Discord.Interactions;
using Kumibot.Database.Repositories;
using Microsoft.VisualBasic;

namespace Kumibot.App.Interactions.MessageComponents.Responses.SelectList;

public class ProcessMatchUpResultsMatchUpSelectListResponse : InteractionBase
{
    private readonly BettingEventRepository _bettingEventRepository;

    public ProcessMatchUpResultsMatchUpSelectListResponse(BettingEventRepository bettingEventRepository)
    {
        _bettingEventRepository = bettingEventRepository;
    }
    
    [ComponentInteraction("process_match_up_results_match_up_select_list")]
    public async Task ComponentResponse()
    {
        var interaction = (IComponentInteraction)Interaction;
        var valueCombo = interaction.Data.Values.FirstOrDefault();
        var splitValue = valueCombo?.Split('_');
        var bettingEventId = splitValue?[0];
        var matchUpPosition = int.Parse(splitValue?[1] ?? string.Empty);
        var bettingEvent =
            await _bettingEventRepository.GetBettingEventById(bettingEventId ?? string.Empty);
        var matchUp = bettingEvent.MatchUps.FirstOrDefault(x => x.Position.Equals(matchUpPosition));
        var selectMenuBuilder = new SelectMenuBuilder().WithCustomId("process_match_up_results_winner_select_list");
        selectMenuBuilder.AddOption($"{matchUp?.FighterOne.Name}",
                $"{bettingEventId}_{matchUp?.Position}_{matchUp?.FighterOne.Id}");
        selectMenuBuilder.AddOption($"{matchUp?.FighterTwo.Name}",
            $"{bettingEventId}_{matchUp?.Position}_{matchUp?.FighterTwo.Id}");

        var builder = new ComponentBuilder().WithSelectMenu(selectMenuBuilder);
        await RespondAsync("Select the winner of the match-up:", components: builder.Build());
    }
}