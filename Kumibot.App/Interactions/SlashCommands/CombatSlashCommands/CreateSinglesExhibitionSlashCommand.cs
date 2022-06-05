using Discord.Interactions;
using Kumibot.App.Interactions.Components.Modals.CombatModals;
using Kumibot.Database.Models.Combat;
using Kumibot.Database.Repositories.Combat;

namespace Kumibot.App.Interactions.SlashCommands.CombatSlashCommands;

public class CreateSinglesExhibitionSlashCommand : InteractionBase
{
    private readonly CombatEventRepository _combatEventRepository;

    public CreateSinglesExhibitionSlashCommand(CombatEventRepository combatEventRepository)
    {
        _combatEventRepository = combatEventRepository;
    }
    
    [SlashCommand("createsinglesexhibition", "Creates a 1 vs 1 exhibition fight.")]
    public async Task CreateSinglesExhibition(string eventTitle, bool startEvent)
    {
        var newEvent = await _combatEventRepository.Create(new CombatEvent
        {
            EventTitle = eventTitle,
            Type = CombatEventType.SingleExhibition,
            DiscordOwner = User.Id
        });
        if (startEvent) newEvent.Status = CombatEventStatus.Running;
        if (newEvent is not null)
        {
            var modalBuilder = AddSinglesMatchModal.GetAddSinglesMatchUpModal(newEvent.Id);
            await RespondWithModalAsync(modalBuilder.Build());
            await Interaction.RespondAsync($"{Mention} has created a 1 vs 1 exhibition: {eventTitle}!");
        }
    }
}