using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Kumibot.Database.Models.Betting;
using Kumibot.Database.Repositories;
using Kumibot.Database.Repositories.Betting;

namespace Kumibot.App.Interactions.SlashCommands.BettingSlashCommands;

public class CreateBettingEventSlashCommand : InteractionBase
{
    private readonly BettingEventRepository _bettingEventRepository;
    private readonly DiscordSocketClient _discordClient;

    public CreateBettingEventSlashCommand(BettingEventRepository bettingEventRepository, DiscordSocketClient discordClient)
    {
        _bettingEventRepository = bettingEventRepository;
        _discordClient = discordClient;
    }
    //TODO: Hook up startEvent option
    [SlashCommand("createbettingevent", "Creates a betting event for server members to place bets. Adds one match-up to start.")]
    public async Task CreateBettingEvent(string eventTitle, int type, bool startEvent)
    {
        var newEvent = await _bettingEventRepository.CreateBettingEvent(new BettingEvent
        {
            EventTitle = eventTitle
        });
        if (startEvent) newEvent.Status = BettingEventStatus.Running;
        if (newEvent is not null)
        {
            var modalBuilder = new ModalBuilder()
                .WithTitle($"Add Match-Up")
                .WithCustomId("add_match_up")
                .AddTextInput("Betting Event Id", "betting_event_id", TextInputStyle.Short, "", null, null, true,
                    newEvent.Id)
                .AddTextInput(
                    $"Fighter 1 Name",
                    "fighter_1_name", placeholder: "Fighter One", required: true)
                .AddTextInput("Fighter 1 Odds",
                    "fighter_1_odds", placeholder: "+100")
                .AddTextInput(
                    "Fighter 2 Name",
                    "fighter_2_name", placeholder: "Fighter Two", required: true)
                .AddTextInput("Fighter 2 Odds",
                    "fighter_2_odds", placeholder: "-100");

            await RespondWithModalAsync(modalBuilder.Build());
            await Interaction.RespondAsync($"{Mention} has created a betting event for {eventTitle}!");
        }
    }
}