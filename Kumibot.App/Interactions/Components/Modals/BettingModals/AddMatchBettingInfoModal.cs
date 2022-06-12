using Discord;
using Discord.Interactions;
using Kumibot.Database.Models.Combat;

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
    
    public static ModalBuilder GetAddMatchBettingInfoModal(string eventId, Match match, string fighterOne, string fighterTwo)
    {
        return new ModalBuilder()
            .WithTitle("Add Match Betting Info")
            .WithCustomId(Constants.AddMatchBettingInfoModalId)
            .AddTextInput(Constants.NeededValues, Constants.NeededValuesId, TextInputStyle.Short, "", null, null, true,
                $"{eventId}_{match.Round}_{match.Position}_{match.FighterOneId}_{match.FighterTwoId}")
            .AddTextInput($"{fighterOne} Odds",
                "fighter_1_odds", placeholder: "+100")
            .AddTextInput($"{fighterTwo} Odds",
                "fighter_2_odds", placeholder: "-100");
    }
}