using Discord;
using Discord.Interactions;
using Kumibot.Database.Repositories;

namespace Kumibot.App.Interactions.Components.SelectLists.Responses;

public class AddMatchUpSelectListResponse : InteractionBase
{
    private readonly BettingEventRepository _bettingEventRepository;

    public AddMatchUpSelectListResponse(BettingEventRepository bettingEventRepository)
    {
        _bettingEventRepository = bettingEventRepository;
    }

    [ComponentInteraction("add_match_up_select_list")]
    public async Task ComponentResponse()
    {
        var interaction = (IComponentInteraction)Interaction;
        var bettingEventId = interaction.Data.Values.FirstOrDefault();
        var bettingEvent =
            await _bettingEventRepository.GetBettingEventById(bettingEventId ?? string.Empty);
        if (bettingEvent is not null)
        {
            var modalBuilder = new ModalBuilder()
                .WithTitle($"Add Match-Up")
                .WithCustomId("add_match_up")
                .AddTextInput("Betting Event Id", "betting_event_id", TextInputStyle.Short, "", null, null, true,
                    bettingEvent.Id)
                .AddTextInput(
                    $"Fighter 1 Name",
                    "fighter_1_name", placeholder: "Fighter One", required: true)
                .AddTextInput("Fighter 1 Odds",
                    "fighter_1_odds", placeholder: "+100")
                .AddTextInput(
                    "Fighter 2 Name",
                    "fighter_2_name", placeholder: "Fighter Two", required: true)
                .AddTextInput("Fighter 2 Odds",
                    "fighter_2_odds", placeholder: "-100");

            await RespondWithModalAsync(modalBuilder.Build());
        }
    }
}