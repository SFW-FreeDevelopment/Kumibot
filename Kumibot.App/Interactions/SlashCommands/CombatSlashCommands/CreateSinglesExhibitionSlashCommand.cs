using Discord.Interactions;
using Kumibot.App.Interactions.Components.Modals.CombatModals;
using Kumibot.Database.Models.Combat;
using Kumibot.Database.Repositories.Combat;

namespace Kumibot.App.Interactions.SlashCommands.CombatSlashCommands;
//TODO: Automatically add betting event when CombatEvent is created
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
        var eventToCreate = new CombatEvent
        {
            EventTitle = eventTitle,
            Type = CombatEventType.SingleExhibition,
            DiscordOwner = User.Id
        };
        if (startEvent) eventToCreate.Status = CombatEventStatus.Running;
        var newEvent = await _combatEventRepository.Create(eventToCreate);
        if (newEvent is not null)
        {
            await ReplyAsync($"{Mention} has created a 1 vs 1 exhibition: {eventTitle}!");
            var modalBuilder = AddSinglesMatchModal.GetAddSinglesMatchModal(newEvent.Id);
            await RespondWithModalAsync(modalBuilder.Build());
        }
    }
}