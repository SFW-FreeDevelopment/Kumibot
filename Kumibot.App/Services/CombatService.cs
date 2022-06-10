using Kumibot.Database.Models.Combat;
using Kumibot.Database.Repositories.Combat;

namespace Kumibot.App.Services;

public class CombatService : IKumibotService<CombatEvent>
{
    private CombatEventRepository _combatEventRepository { get; set; }

    public CombatService(CombatEventRepository combatEventRepository)
    {
        _combatEventRepository = combatEventRepository;
    }

    public async Task<List<CombatEvent>> GetAll()
    {
        return await _combatEventRepository.GetAll();
    }

    public async Task<CombatEvent> GetById(string id)
    {
        return await _combatEventRepository.GetById(id);
    }

    public async Task<CombatEvent> Create(CombatEvent data)
    {
        return await _combatEventRepository.Create(data);
    }

    public async Task<CombatEvent> Update(string id, CombatEvent data)
    {
        return await _combatEventRepository.Update(id, data);
    }

    public Task Delete(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<CombatEvent>> GetByDiscordOwner(ulong discordOwnerId)
    {
        return await _combatEventRepository.GetByDiscordOwner(discordOwnerId);
    }
}