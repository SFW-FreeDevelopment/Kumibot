using Discord.Interactions;

namespace Kumibot.App.Interactions.Components.Modals;

public class EnterBetModal: IModal
{
    public string Title => "Enter Bet";
    [InputLabel("Needed Values")]
    [ModalTextInput("needed_values")]
    public string NeededValues { get; set; }
    
    [InputLabel("Betting Amount:")]
    [ModalTextInput("betting_amount", placeholder: "100.00", maxLength: 50)]
    public string BettingAmount { get; set; }
}