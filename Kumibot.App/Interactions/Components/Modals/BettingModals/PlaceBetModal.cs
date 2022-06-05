using Discord;
using Discord.Interactions;

namespace Kumibot.App.Interactions.Components.Modals.BettingModals;
// TODO: Add PlaceBetModalResponse
public class PlaceBetModal : IModal
{
    public string Title { get; } = "Place Bet";
    
    [InputLabel(Constants.NeededValues)]
    [ModalTextInput(Constants.NeededValuesId)]
    public string NeededValues { get; set; }
    
    [InputLabel("Fighter/Team 1 Odds")]
    [ModalTextInput("betting_amount", placeholder: "+100", maxLength: 20)]
    public string BettingAmount { get; set; }
    
    public static ModalBuilder GetPlaceBetModal(string eventId, string matchPosition, string matchRound, string fighterId)
    {
        return new ModalBuilder()
            .WithTitle("Place Bet")
            .WithCustomId(Constants.PlaceBetModal)
            .AddTextInput(Constants.NeededValues, Constants.NeededValuesId, TextInputStyle.Short, "", null, null, true,
                $"{eventId}_{matchPosition}_{matchRound}_{fighterId}")
            .AddTextInput($"Betting Amount",
                "betting_amount", placeholder: "1000.00");
    }
}