using Discord;
using Discord.Interactions;
using Kumibot.App.Interactions.Components.Modals.BettingModals;
using Kumibot.App.Services;
using Kumibot.Database.Models.Betting;
using Kumibot.Database.Models.Combat;

namespace Kumibot.App.Interactions.Components.SelectLists.BettingSelectLists.Responses;

public class PlaceBetFighterSelectListResponse : InteractionBase
{
    private readonly BettingService _bettingService;
    private readonly CombatService _combatService;
    private readonly FighterService _fighterService;
    // TODO: Finish logic for Switch
    public PlaceBetFighterSelectListResponse(BettingService bettingService, CombatService combatService, FighterService fighterService)
    {
        _bettingService = bettingService;
        _combatService = combatService;
        _fighterService = fighterService;
    }

    [ComponentInteraction(Constants.PlaceBetFighterSelectListId)]
    public async Task ComponentResponse()
    {
        var interaction = (IComponentInteraction)Interaction;
        var splitValueStrings = interaction.Data.Values.FirstOrDefault()?.Split("_");
        var combatEventId = splitValueStrings?[0];
        var fighterId = splitValueStrings?[1];
        var combatEvent =
            await _combatService.GetById(combatEventId ?? string.Empty);
        var matches = combatEvent.Matches;
        var bettingEvent = await _bettingService.GetByCombatEventId(combatEvent.Id);
        bettingEvent ??= await _bettingService.Create(new BettingEvent
        {
            CombatEventId = combatEvent.Id
        });
        if (!bettingEvent.Equals(null))
        {
            switch (combatEvent.Type)
            {
                case CombatEventType.FightCard:
                    break;
                case CombatEventType.SingleExhibition:
                    var match = matches.FirstOrDefault();
                    var placeBetModal = PlaceBetModal.GetPlaceBetModal(combatEventId, match?.Position.ToString(), match?.Round.ToString(), fighterId);
                    break;
                case CombatEventType.Team:
                    break;
                case CombatEventType.TeamTournament:
                    break;
                case CombatEventType.Tournament:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        else
        {
            await RespondAsync("Cannot place bet at this time.");
        }
    }
}