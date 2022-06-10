using Discord.Interactions;
using Discord.WebSocket;
using Kumibot.App.Interactions.Components.Modals.CombatModals;
using Kumibot.Database.Models.Combat;
using Kumibot.Database.Repositories.Combat;

namespace Kumibot.App.Interactions.SlashCommands.CombatSlashCommands;
//TODO: Automatically add betting event when CombatEvent is created
public class CreateSinglesTournamentSlashCommand : InteractionBase
{
    private readonly CombatEventRepository _combatEventRepository;
    private readonly DiscordSocketClient _discordClient;

    public CreateSinglesTournamentSlashCommand(CombatEventRepository combatEventRepository, DiscordSocketClient discordClient)
    {
        _combatEventRepository = combatEventRepository;
        _discordClient = discordClient;
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
        var newEvent = await _combatEventRepository.Create(eventToCreate);
        if (newEvent is not null)
        {
            await ReplyAsync($"{Mention} has created a 1 vs 1 tournament: {eventTitle}!");
            var modalBuilder = AddSinglesMatchModal.GetAddSinglesMatchModal(newEvent.Id);
            await RespondWithModalAsync(modalBuilder.Build());
        }
    }
}