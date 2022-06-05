using Discord;
using Discord.Interactions;

namespace Kumibot.App.Interactions.Components.Modals.CombatModals;

[Group("kumibot", "Kumibot commands")]
public class AddSinglesMatchUpModal : IModal
{
    public string Title => "Add Singles Match-Up";
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

    public static ModalBuilder GetAddSinglesMatchUpModal(string eventId)
    {
        return new ModalBuilder()
            .WithTitle($"Add Match-Up")
            .WithCustomId("add_match_up")
            .AddTextInput("Betting Event Id", "betting_event_id", TextInputStyle.Short, "", null, null, true,
                eventId)
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
    }
}