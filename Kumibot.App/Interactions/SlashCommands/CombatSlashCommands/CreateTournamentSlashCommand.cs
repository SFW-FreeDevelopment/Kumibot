using Discord.Interactions;
using Discord.WebSocket;
using Kumibot.Database.Repositories;

namespace Kumibot.App.Interactions.SlashCommands.CombatSlashCommands;

public class CreateTournamentSlashCommand
{
    private readonly CombatEventRepository _combatEventRepository;
    private readonly DiscordSocketClient _discordClient;

    public CreateTournamentSlashCommand(CombatEventRepository combatEventRepository, DiscordSocketClient discordClient)
    {
        _combatEventRepository = combatEventRepository;
        _discordClient = discordClient;
    }
    //TODO: Hook up startEvent option
    [SlashCommand("createsinglestournament", "Creates a 1 vs 1 tournament")]
    public async Task CreateSinglesTournament(string eventTitle, bool startNow)
    {
        
    }
}