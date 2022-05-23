using System.ComponentModel;
using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Kumibot.Database.Repositories;

namespace Kumibot.App.Interactions.MessageComponents.Responses;

public class PlaceBetSelectListResponse : InteractionBase
{
    private readonly BettingEventRepository _bettingEventRepository;

    public PlaceBetSelectListResponse(BettingEventRepository bettingEventRepository)
    {
        _bettingEventRepository = bettingEventRepository;
    }

    [ComponentInteraction("place_bet_select_list")]
    public async Task ComponentResponse()
    {
        var interaction = (IComponentInteraction)Interaction;
        var bettingEventId = interaction.Data.Values.FirstOrDefault();
        var bettingEvent =
            await _bettingEventRepository.GetBettingEventById(bettingEventId ?? string.Empty);
        var matchUps = bettingEvent.MatchUps;
        var selectMenuBuilder = new SelectMenuBuilder().WithCustomId("place_bet_match_up_select_list");
        foreach (var matchUp in matchUps)
        {
            selectMenuBuilder.AddOption($"{matchUp.FighterOne} vs {matchUp.FighterTwo}", $"{bettingEventId}_{matchUp.Position}");
        }
        var builder = new ComponentBuilder().WithSelectMenu(selectMenuBuilder);
        await RespondAsync("Select the match-up to bet on:", components: builder.Build());
        // var modalBuilder = new ModalBuilder()
        //     .WithTitle($"Place Bets for {bettingEvent.EventTitle}")
        //     .WithCustomId("place_bet_form")
        //     .AddTextInput("Betting Event Id", "betting_event_id", TextInputStyle.Short, "", null, null, true,
        //         bettingEventId);
        // foreach (var matchUp in bettingEvent.MatchUps)
        // {
        //     modalBuilder.AddTextInput(
        //         $"1 for {matchUp.FighterOne} {GetOddsSign(matchUp.FighterOneOdds)}{Math.Abs(matchUp.FighterOneOdds)}, 2 for {matchUp.FighterTwo} {GetOddsSign(matchUp.FighterTwoOdds)}{Math.Abs(matchUp.FighterTwoOdds)}",
        //         $"match_up_{matchUp.Position}", placeholder: "Enter 1 or 2");
        //     modalBuilder.AddTextInput($"Amount to bet on {matchUp.FighterOne} vs {matchUp.FighterTwo}",
        //         $"match_up_{matchUp.Position}_amount", value: "0.00");
        // }
        //
        // await RespondWithModalAsync(modalBuilder.Build());
    }

    private static char GetOddsSign(int odds)
    {
        return odds > 0 ? '+' : '-';
    }
}