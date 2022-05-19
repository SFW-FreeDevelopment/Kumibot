using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Kumibot.Database.Repositories;

namespace Kumibot.App.Interactions.Modals.Responses;

public class PlaceBetFormModalResponse : InteractionBase
{
    private BettingEventRepository _bettingEventRepository;

    public PlaceBetFormModalResponse(BettingEventRepository bettingEventRepository)
    {
        _bettingEventRepository = bettingEventRepository;
    }
    
    [ModalInteraction("place_bet_form")]
    public async Task ModalResponse(PlaceBetFormModal modal)
    {
        var modalInteraction = (IModalInteraction)Interaction;
        var bettingEventId = modalInteraction.Data.Components.FirstOrDefault(x => x.CustomId.Equals("betting_event_id"))?.Value;
        var fighterChoices = modalInteraction.Data.Components.Where(x => x.CustomId.Contains("match_up") && !x.CustomId.Contains("_amount")).Select(x => x.Value).ToList();
        var betAmounts = modalInteraction.Data.Components.Where(x => x.CustomId.Contains("match_up") && x.CustomId.Contains("_amount")).Select(x => x.Value).ToList();
        for (var i = 0; i < fighterChoices.Count; i++)
        {
            
        }
        await ReplyAsync("You reached me!");
    }
}