using System;
using Walks.API.Models.Entities;

namespace Walks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<IList<WalkEntity>> GetAllAsync();
        Task<WalkEntity> GetAsync(Guid id);
        Task<WalkEntity> AddAsync(WalkEntity walkEntity);
        Task DeleteAsync(Guid id);
        Task<WalkEntity> UpdateAsync(WalkEntity walkEntity);
    }
}
