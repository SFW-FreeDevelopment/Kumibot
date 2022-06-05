using Discord.Interactions;
using Kumibot.App.Services;
using Kumibot.Database.Models.Combat;
using Kumibot.Database.Repositories.Combat;

namespace Kumibot.App.Interactions.Components.Modals.CombatModals.Responses;

public class AddSinglesMatchModalResponse : InteractionBase
{
    private readonly CombatEventRepository _combatEventRepository;
    private readonly FighterService _fighterService;

    public AddSinglesMatchModalResponse(CombatEventRepository combatEventRepository, FighterService fighterService)
    {
        _combatEventRepository = combatEventRepository;
        _fighterService = fighterService;
    }
    //TODO: Look into combatEvent not updating in DB
    [ModalInteraction("add_singles_match")]
    public async Task ModalResponse(AddSinglesMatchModal modal)
    {
        var combatEvent = await _combatEventRepository.GetById(modal.NeededValuesId);
        var fighterOne = await _fighterService.Create(new Fighter { Name = modal.FighterOneName });
        var fighterTwo = await _fighterService.Create(new Fighter { Name = modal.FighterTwoName });
        if (fighterOne.Equals(null) || fighterTwo.Equals(null)) await ReplyAsync("Can't create match.");
        else
        {
            combatEvent.Matches.Add(new Match());
            await _combatEventRepository.Update(combatEvent.Id, combatEvent);
            await ReplyAsync($"{Mention} added a match to {combatEvent.EventTitle}. {fighterOne.Name} vs {fighterTwo.Name}");
        }
    }
}