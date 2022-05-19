using Discord;
using Discord.Interactions;

namespace Kumibot.App.Interactions.Modals.Responses;

public class CreateBettingEventModalResponse : InteractionBase
{
    [ModalInteraction("create_betting_form")]
    public async Task ModalResponse(CreateBettingEventModal modal)
    {
        // Build the message to send.
        var message = $"Betting started for {modal.EventTitle}.";

        // Specify the AllowedMentions so we don't actually ping everyone.
        AllowedMentions mentions = new();
        mentions.AllowedTypes = AllowedMentionTypes.Users;

        // Respond to the modal.
        await ReplyAsync(message, allowedMentions: mentions);
    }
}