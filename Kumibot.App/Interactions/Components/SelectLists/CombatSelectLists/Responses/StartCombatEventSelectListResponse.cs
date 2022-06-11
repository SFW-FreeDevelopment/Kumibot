using Discord;
using Discord.Interactions;
using Kumibot.App.Interactions.Components.Modals.BettingModals;
using Kumibot.App.Services;
using Kumibot.Database.Models.Betting;
using Kumibot.Database.Models.Combat;
using Kumibot.Exceptions;

namespace Kumibot.App.Interactions.Components.SelectLists.CombatSelectLists.Responses;

public class StartCombatEventSelectListResponse : InteractionBase
{
    private readonly BettingService _bettingService;
    private readonly CombatService _combatService;
    
    public StartCombatEventSelectListResponse(BettingService bettingService, CombatService combatService)
    {
        _bettingService = bettingService;
        _combatService = combatService;
    }

    [ComponentInteraction(Constants.StartCombatEventCombatEventSelectListId)]
    public async Task ComponentResponse()
    {
        try
        {
            var interaction = (IComponentInteraction)Interaction;
            var combatEventId = interaction.Data.Values.FirstOrDefault();
            var combatEvent =
                await _combatService.GetById(combatEventId ?? string.Empty);
            if (!combatEvent.Equals(null))
            {
                var bettingEvent = await _bettingService.GetByCombatEventId(combatEvent.Id);
                if (!bettingEvent.Equals(null))
                {
                    bettingEvent.IsActive = true;
                    combatEvent.Status = CombatEventStatus.Running;
                    await _combatService.Update(combatEvent.Id, combatEvent);
                    await _bettingService.Update(bettingEvent.Id, bettingEvent);
                    await ReplyAsync($"{combatEvent.EventTitle} has started!");
                }
                else
                {
                    await ReplyAsync("Could not start event.");
                }
            }
            else
            {
                await ReplyAsync("Could not start event.");
            }
        }
        catch (KumibotException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}