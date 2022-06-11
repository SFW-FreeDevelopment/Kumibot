using Discord;
using Discord.Interactions;
using Kumibot.App.Helpers;
using Kumibot.App.Interactions.Components.Modals.CombatModals;
using Kumibot.App.Services;
using Kumibot.Database.Models.Combat;

namespace Kumibot.App.Interactions.Components.SelectLists.CombatSelectLists.Responses;
public class AddSinglesMatchCombatEventSelectListResponse : InteractionBase
{
    [ComponentInteraction(Constants.AddSinglesMatchCombatEventSelectListId)]
    public async Task ComponentResponse()
    {
        var interaction = (IComponentInteraction)Interaction;
        var combatEventId = interaction.Data.Values.FirstOrDefault();
        if (!string.IsNullOrWhiteSpace(combatEventId))
        {
            var modalBuilder = AddSinglesMatchModal.GetAddSinglesMatchModal(combatEventId);
            await RespondWithModalAsync(modalBuilder.Build());
        }
        else
        {
            await ReplyAsync("Could not add match.");
        }
    }
}