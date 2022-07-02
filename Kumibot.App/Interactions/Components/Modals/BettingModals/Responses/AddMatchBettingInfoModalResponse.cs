using Discord.Interactions;
using Kumibot.App.Interactions.Components.Modals.CombatModals;
using Kumibot.App.Services;
using Kumibot.Database.Models.Betting;

namespace Kumibot.App.Interactions.Components.Modals.BettingModals.Responses;

//TODO: Process AddMatchBettingInfo modal
public class AddMatchBettingInfoModalResponse : InteractionBase
{
    private readonly CombatService _combatService;
    private readonly FighterService _fighterService;
    private readonly BettingService _bettingService;

    public AddMatchBettingInfoModalResponse(CombatService combatService, FighterService fighterService,
        BettingService bettingService)
    {
        _combatService = combatService;
        _fighterService = fighterService;
        _bettingService = bettingService;
    }

    [ModalInteraction(Constants.AddMatchBettingInfoModalId)]
    public async Task ModalResponse(AddMatchBettingInfoModal modal)
    {
        var stringValues = modal.NeededValues.Split("_");
        var combatEventId = stringValues[0];
        var matchRound = int.Parse(stringValues[1]);
        var matchPosition = int.Parse(stringValues[2]);
        var combatEvent = await _combatService.GetById(combatEventId);
        var match = combatEvent.Matches.FirstOrDefault(x =>
            x.Round.Equals(matchRound) && x.Position.Equals(matchPosition));
        if (match != null)
        {
            var bettingEvent = await _bettingService.GetByCombatEventId(combatEvent.Id);
            bettingEvent.Odds.Add(new Odds
            {
                MatchRound = match.Round,
                MatchPosition = match.Position,
                FighterOneId = match.FighterOneId,
                FighterOneOdds = int.Parse(modal.PositionOneOdds),
                FighterTwoId = match.FighterTwoId,
                FighterTwoOdds = int.Parse(modal.PositionTwoOdds)
            });
        }

        await _combatService.Update(combatEvent.Id, combatEvent);
        /*await ReplyAsync(
            $"{Mention} added a match to {combatEvent.EventTitle}. {fighterOne.Name} vs {fighterTwo.Name}");*/
    }
}