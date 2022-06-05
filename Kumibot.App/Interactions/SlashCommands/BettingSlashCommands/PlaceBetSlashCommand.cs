﻿using Discord;
using Discord.Interactions;
using Kumibot.Database.Repositories.Betting;

namespace Kumibot.App.Interactions.SlashCommands.BettingSlashCommands;

public class PlaceBetSlashCommand : InteractionBase
{
    private readonly BettingEventRepository _bettingEventRepository;

    public PlaceBetSlashCommand(BettingEventRepository bettingEventRepository)
    {
        _bettingEventRepository = bettingEventRepository;
    }
    
    [DefaultMemberPermissions(GuildPermission.UseApplicationCommands)]
    [SlashCommand("placebet", "Place a bet on an ongoing event's match-up", ignoreGroupNames: true)]
    public async Task PlaceBet()
    {
        var bettingEvents = await _bettingEventRepository.GetRunningBettingEvents();
        var selectMenuBuilder = new SelectMenuBuilder().WithCustomId("place_bet_select_list");
        foreach (var bettingEvent in bettingEvents)
        {
            selectMenuBuilder.AddOption(bettingEvent.EventTitle, bettingEvent.Id);
        }
        var builder = new ComponentBuilder().WithSelectMenu(selectMenuBuilder);
        await RespondAsync("Select the event to bet on:", components: builder.Build());
    }
}