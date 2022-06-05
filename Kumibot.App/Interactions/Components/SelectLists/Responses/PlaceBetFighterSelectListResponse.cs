using Discord;
using Discord.Interactions;
using Kumibot.Database.Repositories;
using Kumibot.Database.Repositories.Betting;

namespace Kumibot.App.Interactions.Components.SelectLists.Responses;

public class PlaceBetFighterSelectListResponse: InteractionBase
{
    private readonly BettingEventRepository _bettingEventRepository;
    
    public PlaceBetFighterSelectListResponse(BettingEventRepository bettingEventRepository)
    {
        _bettingEventRepository = bettingEventRepository;
    }

    [ComponentInteraction("place_bet_fighter_select_list")]
    public async Task ComponentResponse()
    {
        var interaction = (IComponentInteraction)Interaction;
        var valueCombo = interaction.Data.Values.FirstOrDefault();
        var splitValue = valueCombo?.Split('_');
        var bettingEventId = splitValue?[0];
        var matchUpPosition = int.Parse(splitValue?[1] ?? string.Empty);
        var fighterId = splitValue?[2];
        var bettingEvent =
            await _bettingEventRepository.GetBettingEventById(bettingEventId ?? string.Empty);
        var matchUp = bettingEvent.MatchUps.FirstOrDefault(x => x.Position.Equals(matchUpPosition));
        var modalBuilder = new ModalBuilder()
            .WithTitle($"Enter Bet")
            .WithCustomId("place_bet_fighter_amount")
            .AddTextInput("Needed Values", "needed_values", TextInputStyle.Short, "", null, null, true,
                $"{bettingEventId}_{matchUp?.Position}_{fighterId}")
            .AddTextInput(
                $"Betting Amount",
                "betting_amount", placeholder: "100.00", required: true);

        await RespondWithModalAsync(modalBuilder.Build());
    }
}