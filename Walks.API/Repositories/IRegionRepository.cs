using System;
using Walks.API.Models.Domain;

namespace Walks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<IList<Region>> GetAllAsync();
        Task<Region> GetAsync(Guid id);
        Task<Region> AddAsync(Region region);
        Task DeleteAsync(Guid id);
        Task<Region> UpdateAsync(Region region);
    }
}
