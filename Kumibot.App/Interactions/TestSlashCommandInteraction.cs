using Discord;
using Discord.Interactions;

namespace Kumibot.App.Interactions;

[Group("kumibot", "Kumibot commands")]
public class TestSlashCommandInteraction : InteractionBase
{
    [SlashCommand("test", "Hello test")]
    public async Task Test() => await Interaction.RespondWithModalAsync<FoodModal>("food_menu");
    //public async Task Test() => await RespondAsync("Testing!");
}

[Group("kumibot", "Kumibot commands")]
public class FoodModal : IModal
{
    public string Title => "Fav Food";
    // Strings with the ModalTextInput attribute will automatically become components.
    [InputLabel("What??")]
    [ModalTextInput("food_name", placeholder: "Pizza", maxLength: 20)]
    public string Food { get; set; }

    // Additional paremeters can be specified to further customize the input.
    [InputLabel("Why??")]
    [ModalTextInput("food_reason", TextInputStyle.Paragraph, "Kuz it's tasty", maxLength: 500)]
    public string Reason { get; set; }
}