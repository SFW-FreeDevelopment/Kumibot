using Discord;
using Discord.Interactions;
using Discord.WebSocket;

namespace Kumibot.App.Interactions.Modals.Responses;

public class PlaceBetFormModalResponse : InteractionBase
{
    [ModalInteraction("place_bet_form")]
    public async Task ModalResponse(PlaceBetFormModal modal)
    {
        var thing = modal;
        var thingy = Interaction.Data as SocketModalData;
        await ReplyAsync("You reached me!");
    }
}