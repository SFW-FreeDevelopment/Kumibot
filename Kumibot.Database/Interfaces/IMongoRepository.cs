using Kumibot.Database.Models;

namespace Kumibot.Database.Interfaces;

public interface IMongoRepository<T> where T : BaseResource
{
    public Task<List<T>> GetAll();
    public Task<T> GetById(string id);
    public Task<T> Create(T data);
    public Task<T> Update(string id, T data);
    public Task Delete(string id);
}