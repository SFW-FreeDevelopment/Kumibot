using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Kumibot.App.Interactions.Components.Modals;
using Kumibot.App.Interactions.Components.Modals.CombatModals;
using Kumibot.Database.Models.Betting;
using Kumibot.Database.Models.Combat;
using Kumibot.Database.Repositories;
using Kumibot.Database.Repositories.Combat;

namespace Kumibot.App.Interactions.SlashCommands.CombatSlashCommands;

public class CreateSinglesExhibitionSlashCommand : InteractionBase
{
    private readonly CombatEventRepository _combatEventRepository;
    private readonly DiscordSocketClient _discordClient;

    public CreateSinglesExhibitionSlashCommand(CombatEventRepository combatEventRepository, DiscordSocketClient discordClient)
    {
        _combatEventRepository = combatEventRepository;
        _discordClient = discordClient;
    }
    //TODO: Hook up startEvent option
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
            var modalBuilder = AddSinglesMatchUpModal.GetAddSinglesMatchUpModal(newEvent.Id);
            await RespondWithModalAsync(modalBuilder.Build());
            await Interaction.RespondAsync($"{Mention} has created a betting event for {eventTitle}!");
        }
    }
}