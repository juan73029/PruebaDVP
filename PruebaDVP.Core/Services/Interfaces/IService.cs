using System;
namespace PruebaDVP.Core.Services.Interfaces
{
    public interface IService<T, DTO> where T : class
                                                where DTO : class
    {
        Task<List<DTO>> Get();
        Task<DTO?> Get(int id);
        Task<DTO> Update(DTO element, int id);
        Task<bool> Delete(int id);
        Task<DTO> Add(DTO element);
    }
}

