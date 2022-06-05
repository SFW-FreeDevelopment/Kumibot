using Discord.Interactions;

namespace Kumibot.App.Interactions.Components.Modals.BettingModals;

public class AddMatchUpBettingInfoModal : IModal
{
    public string Title => "Add Singles Match-Up";
    
    [InputLabel("Needed Values Id")]
    [ModalTextInput("needed_values_id")]
    public string NeededValuesId { get; set; }
    
    [InputLabel("Fighter/Team 1 Odds")]
    [ModalTextInput("position_1_odds", placeholder: "+100", maxLength: 20)]
    public string PositionOneOdds { get; set; }
    
    [InputLabel("Fighter/Team 2 Odds")]
    [ModalTextInput("position_2_odds", placeholder: "-100", maxLength: 20)]
    public string PositionTwoOdds { get; set; }
}