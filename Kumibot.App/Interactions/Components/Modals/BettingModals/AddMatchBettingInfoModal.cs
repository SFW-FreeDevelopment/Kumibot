using Discord;
using Discord.Interactions;

namespace Kumibot.App.Interactions.Components.Modals.BettingModals;
//TODO: Add AddMatchBettingInfoModal
public class AddMatchBettingInfoModal : IModal
{
    public string Title => "Add Match Betting Info";
    
    [InputLabel(Constants.NeededValues)]
    [ModalTextInput(Constants.NeededValuesId)]
    public string NeededValues { get; set; }
    
    [InputLabel("Fighter/Team 1 Odds")]
    [ModalTextInput("position_1_odds", placeholder: "+100", maxLength: 20)]
    public string PositionOneOdds { get; set; }
    
    [InputLabel("Fighter/Team 2 Odds")]
    [ModalTextInput("position_2_odds", placeholder: "-100", maxLength: 20)]
    public string PositionTwoOdds { get; set; }
    
    public static ModalBuilder GetAddMatchBettingInfoModal(string eventId, string matchUpPosition, string matchUpRound, string subjectOne, string subjectTwo)
    {
        return new ModalBuilder()
            .WithTitle("Add Match Betting Info")
            .WithCustomId("add_match_betting_info")
            .AddTextInput(Constants.NeededValues, Constants.NeededValuesId, TextInputStyle.Short, "", null, null, true,
                $"{eventId}")
            .AddTextInput($"{subjectOne} Odds",
                "fighter_1_odds", placeholder: "+100")
            .AddTextInput($"{subjectTwo} Odds",
                "fighter_2_odds", placeholder: "-100");
    }
}