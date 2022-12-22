using System;
using Walks.API.Models.DTOs;

namespace Walks.API.Services
{
    public interface IRegionService
    {
        Task<IList<Region>> GetAllAsync();

        Task<Region> GetAsync(Guid id);

        Task<Region> AddAsync(AddRegionRequest addRegionRequest);

        Task DeleteAsync(Guid id);

        Task<Region> UpdateAsync(Guid id, UpdateRegionRequest updateRegionRequest);
    }
}
