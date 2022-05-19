using System.ComponentModel;
using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Kumibot.Database.Repositories;

namespace Kumibot.App.Interactions.MessageComponents.Responses;

public class PlaceBetSelectMenuResponse : InteractionBase
{
    private BettingEventRepository _bettingEventRepository;

    public PlaceBetSelectMenuResponse(BettingEventRepository bettingEventRepository)
    {
        _bettingEventRepository = bettingEventRepository;
    }
    
    [ComponentInteraction("betting_event_select_list")]
    public async Task ComponentResponse()
    {
        var testId = "0e060eb9-749a-4736-8a34-1ff314ee16f0";
        var testEvent = await _bettingEventRepository.GetBettingEventById(Guid.Parse(testId));
        var modalBuilder = new ModalBuilder()
            .WithTitle($"Place Bets for {testEvent.EventTitle}")
            .WithCustomId("bet_form");
        foreach (var matchUp in testEvent.MatchUps)
        {
            modalBuilder.AddTextInput($"1 for {matchUp.FighterOne}/{matchUp.FighterOneOdds}, 2 for {matchUp.FighterTwo}/{matchUp.FighterTwoOdds}", $"match_up_{matchUp.Position}");
            modalBuilder.AddTextInput($"Amount to bet for {matchUp.FighterOne} vs {matchUp.FighterTwo}", $"match_up_{matchUp.Position}_amount", placeholder:"500.00");
        }
        await RespondWithModalAsync(modalBuilder.Build());
    }
}