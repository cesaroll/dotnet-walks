using System;
using Walks.API.Models.Entities;

namespace Walks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<IList<RegionEntity>> GetAllAsync();
        Task<RegionEntity> GetAsync(Guid id);
        Task<RegionEntity> AddAsync(RegionEntity regionEntity);
        Task DeleteAsync(Guid id);
        Task<RegionEntity> UpdateAsync(RegionEntity regionEntity);
    }
}
