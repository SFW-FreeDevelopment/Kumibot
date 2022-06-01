using Discord;
using Discord.Interactions;
using Kumibot.Database.Repositories;

namespace Kumibot.App.Interactions.MessageComponents.Responses.SelectList;

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
        var fighterIdString = splitValue?[1];
        var fighterId = long.Parse(fighterIdString ?? string.Empty);
        var bettingEvent =
            await _bettingEventRepository.GetBettingEventById(bettingEventId ?? string.Empty);
        var matchUp = bettingEvent.MatchUps.FirstOrDefault(x => x.FighterOneId.Equals(fighterId) || x.FighterTwoId.Equals(fighterId));
        var textInputBuilder = new TextInputBuilder().WithCustomId("place_bet_fighter_amount");
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