using Discord;
using Discord.Interactions;
using Kumibot.App.Interactions.SlashCommands;

namespace Kumibot.App.Interactions.Modals.ModalResponses;

public class FoodMenuModalResponse : InteractionBase
{
    [ModalInteraction("food_menu")]
    public async Task ModalResponse(FoodModal modal)
    {
        // Build the message to send.
        var message = "I just learned " +
                      $"{Mention}'s favorite food is " +
                      $"{modal.Food} because {modal.Reason}.";

        // Specify the AllowedMentions so we don't actually ping everyone.
        AllowedMentions mentions = new();
        mentions.AllowedTypes = AllowedMentionTypes.Users;

        // Respond to the modal.
        await ReplyAsync(message, allowedMentions: mentions);
    }
}