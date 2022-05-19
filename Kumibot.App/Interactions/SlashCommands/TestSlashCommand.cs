using Discord.Interactions;
using Kumibot.App.Interactions.Modals;

namespace Kumibot.App.Interactions.SlashCommands;

public class TestSlashCommand : InteractionBase
{
    [SlashCommand("test", "Hello test")]
    public async Task Test() => await Interaction.RespondWithModalAsync<FoodModal>("food_menu");
    //public async Task Test() => await RespondAsync("Testing!");
}