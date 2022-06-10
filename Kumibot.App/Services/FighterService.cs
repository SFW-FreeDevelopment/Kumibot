using Kumibot.Database.Models.Combat;
using Kumibot.Database.Repositories.Combat;

namespace Kumibot.App.Services;

public class FighterService : IKumibotService<Fighter>
{
    private readonly FighterRepository _fighterRepository;
    private readonly CombatEventRepository _combatEventRepository;

    public FighterService(FighterRepository fighterRepository, CombatEventRepository combatEventRepository)
    {
        _fighterRepository = fighterRepository;
        _combatEventRepository = combatEventRepository;
    }

    public Task<List<Fighter>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<Fighter> GetById(string id)
    {
        return await _fighterRepository.GetById(id);
    }

    public async Task<Fighter> Create(Fighter data)
    {
        var fighter = await _fighterRepository.GetFighterByName(data.Name);
        if (fighter is not null) return fighter;
        fighter = await _fighterRepository.Create(data);
        return fighter;
    }

    public Task<Fighter> Update(string id, Fighter data)
    {
        throw new NotImplementedException();
    }

    public Task Delete(string id)
    {
        throw new NotImplementedException();
    }
}