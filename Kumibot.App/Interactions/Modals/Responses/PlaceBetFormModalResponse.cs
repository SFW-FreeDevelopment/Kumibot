using Discord;
using Discord.Interactions;
using Kumibot.Database.Models.Betting;
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
        var bettingEvent = await _bettingEventRepository.GetBettingEventById(bettingEventId ?? string.Empty);
        for (var i = 0; i < fighterChoices.Count; i++)
        {
            var matchUp = bettingEvent.MatchUps.FirstOrDefault(mu => mu.Position.Equals(i + 1));
            var fighter = "";
            switch (fighterChoices[i])
            {
                case "1":
                    fighter = matchUp?.FighterOne;
                    break;
                case "2":
                    fighter = matchUp?.FighterTwo;
                    break;
                default:
                    break;
            }
            var betExists = bettingEvent.Bets.Exists(x => x.Owner.Equals(User.Id) && x.Fighter.Equals(matchUp?.FighterOne) || x.Fighter.Equals(matchUp?.FighterTwo));
            var newBet = new Bet
            {
                Owner = User.Id,
                DollarAmount = double.Parse(betAmounts[i]),
                Fighter = fighter,
                
            };
            if (!betExists) bettingEvent.Bets.Add(newBet);
        }
        
        await _bettingEventRepository.UpdateBettingEvent(bettingEvent.Id, bettingEvent);
        await ReplyAsync("You reached me!");
    }
}