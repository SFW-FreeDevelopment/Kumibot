﻿using Discord.Interactions;
using Discord.WebSocket;
using Kumibot.Database.Repositories.Combat;

namespace Kumibot.App.Interactions.SlashCommands.CombatSlashCommands;
//TODO: Automatically add betting event when CombatEvent is created
public class CreateSinglesTournamentSlashCommand
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
        
    }
}