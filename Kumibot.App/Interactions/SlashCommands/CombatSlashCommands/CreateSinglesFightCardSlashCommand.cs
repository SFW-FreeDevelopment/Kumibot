using Discord.Interactions;
using Kumibot.App.Interactions.Components.Modals.CombatModals;
using Kumibot.App.Services;
using Kumibot.Database.Models.Betting;
using Kumibot.Database.Models.Combat;

namespace Kumibot.App.Interactions.SlashCommands.CombatSlashCommands;

public class CreateSinglesFightCardSlashCommand : InteractionBase
{
    
    private readonly CombatService _combatService;
    private readonly BettingService _bettingService;

    public CreateSinglesFightCardSlashCommand(CombatService combatService, BettingService bettingService)
    {
        _combatService = combatService;
        _bettingService = bettingService;
    }
    
    [SlashCommand("createsinglesfightcard", "Creates a 1 vs 1 fight card.")]
    public async Task CreateSinglesFightCard(string eventTitle)
    {
        var combatEventToCreate = new CombatEvent
        {
            EventTitle = eventTitle,
            Type = CombatEventType.SingleExhibition,
            DiscordOwner = User.Id
        };
        var newEvent = await _combatService.Create(combatEventToCreate);
        if (newEvent is not null)
        {
            var bettingEventToCreate = new BettingEvent
            {
                CombatEventId = newEvent.Id
            };
            await _bettingService.Create(bettingEventToCreate);
            await ReplyAsync($"{Mention} has created a 1 vs 1 fight card: {eventTitle}!");
            var modalBuilder = AddSinglesMatchModal.GetAddSinglesMatchModal(newEvent.Id);
            await RespondWithModalAsync(modalBuilder.Build());
        }
    }
}