using Kumibot.Database.Models;

namespace Kumibot.Web.Services;

public interface ICombatService<T> where T : BaseResource
{
    public Task<List<T>> GetAll();
    public Task<T> GetById(string id);
    public Task<T> Create(T data);
    public Task<T> Update(string id, T data);
    public Task Delete(string id);
}