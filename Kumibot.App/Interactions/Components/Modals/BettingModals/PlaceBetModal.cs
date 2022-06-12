using Discord;
using Discord.Interactions;
using Kumibot.Database.Models.Combat;

namespace Kumibot.App.Interactions.Components.Modals.BettingModals;
public class PlaceBetModal : IModal
{
    public string Title { get; } = "Place Bet";
    
    [InputLabel(Constants.NeededValues)]
    [ModalTextInput(Constants.NeededValuesId)]
    public string NeededValues { get; set; }
    
    [InputLabel("Fighter/Team 1 Odds")]
    [ModalTextInput("betting_amount", placeholder: "1000.00")]
    public string BettingAmount { get; set; }
    
    public static ModalBuilder GetPlaceBetModal(string eventId, Match match, string fighterId)
    {
        return new ModalBuilder()
            .WithTitle("Place Bet")
            .WithCustomId(Constants.PlaceBetModalId)
            .AddTextInput(Constants.NeededValues, Constants.NeededValuesId, TextInputStyle.Short, "", null, null, true,
                $"{eventId}_{match.Round}_{match.Position}_{fighterId}")
            .AddTextInput($"Betting Amount",
                "betting_amount", placeholder: "1000.00");
    }
}