using System;
namespace PruebaDVP.Data.Services.Interfaces
{
    public interface IContextService<T> where T : class
    {
        Task<List<T>> Get();
        Task<T?> Get(int id);
        Task<T> Update(int id, T element);
        Task<bool> Delete(int id);
        Task<T> Add(T element);
    }
}

