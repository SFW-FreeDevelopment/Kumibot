using Discord.Interactions;
using Kumibot.App.Interactions.Components.Modals.CombatModals;
using Kumibot.App.Services;
using Kumibot.Database.Models.Combat;

namespace Kumibot.App.Interactions.SlashCommands.CombatSlashCommands;
//TODO: Automatically add betting event when CombatEvent is created
public class CreateSinglesTournamentSlashCommand : InteractionBase
{
    private readonly CombatService _combatService;

    public CreateSinglesTournamentSlashCommand(CombatService combatService)
    {
        _combatService = combatService;
    }

    [SlashCommand("createsinglestournament", "Creates a 1 vs 1 tournament")]
    public async Task CreateSinglesTournament(string eventTitle)
    {
        var eventToCreate = new CombatEvent
        {
            EventTitle = eventTitle,
            Type = CombatEventType.Tournament,
            DiscordOwner = User.Id
        };
        var newEvent = await _combatService.Create(eventToCreate);
        if (newEvent is not null)
        {
            await ReplyAsync($"{Mention} has created a 1 vs 1 tournament: {eventTitle}!");
            var modalBuilder = AddSinglesMatchModal.GetAddSinglesMatchModal(newEvent.Id);
            await RespondWithModalAsync(modalBuilder.Build());
        }
    }
}