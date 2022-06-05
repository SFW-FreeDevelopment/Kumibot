using Discord;
using Discord.Interactions;

namespace Kumibot.App.Interactions.Components.Modals.CombatModals;

[Group("kumibot", "Kumibot commands")]
public class AddSinglesMatchModal : IModal
{
    public string Title => "Add Singles Match";
    
    [InputLabel("Needed Values Id")]
    [ModalTextInput("needed_values_id")]
    public string NeededValuesId { get; set; }
    
    [InputLabel("Fighter 1 Name")]
    [ModalTextInput("fighter_1_name", placeholder: "Fighter 1", maxLength: 50)]
    public string FighterOneName { get; set; }

    [InputLabel("Fighter 2 Name")]
    [ModalTextInput("fighter_2_name", placeholder: "Fighter 2", maxLength: 50)]
    public string FighterTwoName { get; set; }

    public static ModalBuilder GetAddSinglesMatchUpModal(string eventId)
    {
        return new ModalBuilder()
            .WithTitle($"Add Singles Match-Up")
            .WithCustomId("add_singles_match_up")
            .AddTextInput(Constants.NeededValues, Constants.NeededValuesId, TextInputStyle.Short, "", null, null, true,
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