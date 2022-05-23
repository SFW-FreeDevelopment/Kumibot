using Discord.Interactions;

namespace Kumibot.App.Interactions.Modals;

[Group("kumibot", "Kumibot commands")]
public class AddMatchUpModal : IModal
{
    public string Title => "Add Match-Up";
    [InputLabel("Betting Event Id")]
    [ModalTextInput("betting_event_id")]
    public string BettingEventId { get; set; }
    
    [InputLabel("Fighter 1 Name")]
    [ModalTextInput("fighter_1_name", placeholder: "Fighter 1", maxLength: 50)]
    public string FighterOneName { get; set; }
    
    [InputLabel("Fighter 1 Odds")]
    [ModalTextInput("fighter_1_odds", placeholder: "100", maxLength: 20)]
    public string FighterOneOdds { get; set; }

    [InputLabel("Fighter 2 Name")]
    [ModalTextInput("fighter_2_name", placeholder: "Fighter 2", maxLength: 50)]
    public string FighterTwoName { get; set; }
    
    [InputLabel("Fighter 2 Odds")]
    [ModalTextInput("fighter_2_odds", placeholder: "-100", maxLength: 20)]
    public string FighterTwoOdds { get; set; }
}