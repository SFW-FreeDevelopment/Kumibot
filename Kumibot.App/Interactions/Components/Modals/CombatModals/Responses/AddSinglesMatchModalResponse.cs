using Discord.Interactions;
using Kumibot.App.Services;
using Kumibot.Database.Models.Combat;
using Kumibot.Database.Repositories.Combat;

namespace Kumibot.App.Interactions.Components.Modals.CombatModals.Responses;

public class AddSinglesMatchModalResponse : InteractionBase
{
    private readonly CombatService _combatService;
    private readonly FighterService _fighterService;

    public AddSinglesMatchModalResponse(CombatService combatService, FighterService fighterService)
    {
        _combatService = combatService;
        _fighterService = fighterService;
    }
    //TODO: Look into combatEvent not updating in DB
    [ModalInteraction("add_singles_match")]
    public async Task ModalResponse(AddSinglesMatchModal modal)
    {
        var combatEvent = await _combatService.GetById(modal.NeededValuesId);
        var fighterOne = await _fighterService.Create(new Fighter { Name = modal.FighterOneName });
        var fighterTwo = await _fighterService.Create(new Fighter { Name = modal.FighterTwoName });
        if (fighterOne == null || fighterTwo == null) await ReplyAsync("Can't create match.");
        else
        {
            var maxPosition = combatEvent.Matches.Count > 0 ? combatEvent.Matches.Max(x => x.Position) : -1;
            combatEvent.Matches.Add(new Match
            {
                FighterOneId = fighterOne.Id,
                FighterTwoId = fighterTwo.Id,
                Position =  maxPosition < 1 ? 1 : maxPosition + 1
            });
            await _combatService.Update(combatEvent.Id, combatEvent);
            await ReplyAsync($"{Mention} added a match to {combatEvent.EventTitle}. {fighterOne.Name} vs {fighterTwo.Name}");
        }
    }
}