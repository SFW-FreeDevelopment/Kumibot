using Discord;
using Discord.Interactions;

namespace Kumibot.App.Interactions.Components.Modals.BettingModals;

public class AddMatchBettingInfoModal : IModal
{
    public string Title => "Add Match Betting Info";
    
    [InputLabel("Needed Values Id")]
    [ModalTextInput("needed_values_id")]
    public string NeededValuesId { get; set; }
    
    [InputLabel("Fighter/Team 1 Odds")]
    [ModalTextInput("position_1_odds", placeholder: "+100", maxLength: 20)]
    public string PositionOneOdds { get; set; }
    
    [InputLabel("Fighter/Team 2 Odds")]
    [ModalTextInput("position_2_odds", placeholder: "-100", maxLength: 20)]
    public string PositionTwoOdds { get; set; }
    
    public static ModalBuilder GetAddSinglesMatchModal(string eventId)
    {
        return new ModalBuilder()
            .WithTitle($"Add Singles Match")
            .WithCustomId("add_singles_match")
            .AddTextInput(Constants.NeededValues, Constants.NeededValuesId, TextInputStyle.Short, "", null, null, true,
                eventId)
            .AddTextInput("Fighter/Team 1 Odds",
                "fighter_1_odds", placeholder: "+100")
            .AddTextInput("Fighter/Team 2 Odds",
                "fighter_2_odds", placeholder: "-100");
    }
}