using Discord.Interactions;
using Kumibot.Database.Repositories;

namespace Kumibot.App.Interactions.MessageComponents.Responses.SelectList;

public class ProcessMatchUpResultsWinnerSelectListResponse: InteractionBase
{
    private readonly BettingEventRepository _bettingEventRepository;

    public ProcessMatchUpResultsWinnerSelectListResponse(BettingEventRepository bettingEventRepository)
    {
        _bettingEventRepository = bettingEventRepository;
    }

    [ComponentInteraction("process_match_up_results_winner_select_list")]
    public async Task ComponentResponse()
    {
    }
}