using Discord.Interactions;
using Kumibot.App.Interactions.Modals;

namespace Kumibot.App.Interactions.SlashCommands;

public class CreateBettingEventSlashCommand : InteractionBase
{
    [SlashCommand("createbettingevent", "Creates a betting event for server members to place bets.")]
    public async Task CreateBettingEvent() => await Interaction.RespondWithModalAsync<CreateBettingEventModal>("create_betting_form");
}