using Discord.Interactions;
using Kumibot.App.Interactions.Components.Modals.CombatModals;
using Kumibot.App.Services;
using Kumibot.Database.Models.Combat;

namespace Kumibot.App.Interactions.SlashCommands.CombatSlashCommands;

public class CreateSinglesFightCardSlashCommand : InteractionBase
{
    
    private readonly CombatService _combatService;

    public CreateSinglesFightCardSlashCommand(CombatService combatService)
    {
        _combatService = combatService;
    }
    
    [SlashCommand("createsinglesfightcard", "Creates a 1 vs 1 fight card.")]
    public async Task CreateSinglesFightCard(string eventTitle)
    {
        var eventToCreate = new CombatEvent
        {
            EventTitle = eventTitle,
            Type = CombatEventType.SingleExhibition,
            DiscordOwner = User.Id
        };
        var newEvent = await _combatService.Create(eventToCreate);
        if (newEvent is not null)
        {
            await ReplyAsync($"{Mention} has created a 1 vs 1 fight card: {eventTitle}!");
            var modalBuilder = AddSinglesMatchModal.GetAddSinglesMatchModal(newEvent.Id);
            await RespondWithModalAsync(modalBuilder.Build());
        }
    }
}