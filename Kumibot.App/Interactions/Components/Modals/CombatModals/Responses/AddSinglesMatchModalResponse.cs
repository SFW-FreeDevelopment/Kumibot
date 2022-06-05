using Discord.Interactions;
using Kumibot.Database.Models.Combat;
using Kumibot.Database.Repositories.Combat;

namespace Kumibot.App.Interactions.Components.Modals.CombatModals.Responses;

public class AddSinglesMatchModalResponse : InteractionBase
{
    private readonly CombatEventRepository _combatEventRepository;
    private readonly FighterRepository _fighterRepository;

    public AddSinglesMatchModalResponse(CombatEventRepository combatEventRepository, FighterRepository fighterRepository)
    {
        _combatEventRepository = combatEventRepository;
        _fighterRepository = fighterRepository;
    }
    
    [ModalInteraction("add_singles_match")]
    public async Task ModalResponse(AddSinglesMatchModal modal)
    {
        var combatEvent = await _combatEventRepository.GetById(modal.NeededValuesId);
        var fighterOne = await _fighterRepository.Create(new Fighter { Name = modal.FighterOneName });
        var fighterTwo = await _fighterRepository.Create(new Fighter { Name = modal.FighterOneName });
        if (fighterOne.Equals(null) || fighterTwo.Equals(null)) await ReplyAsync("Can't create match.");
        else
        {
            combatEvent.Matches.Add(new Match());
            await ReplyAsync($"{Mention} added a match to {combatEvent.EventTitle}. {fighterOne.Name} vs {fighterTwo.Name}");
        }
    }
}