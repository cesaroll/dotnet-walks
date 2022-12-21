using System;
using Walks.API.Models.DTO;

namespace Walks.API.Services
{
    public interface IRegionService
    {
        Task<IList<RegionDTO>> GetAllAsync();

        Task<RegionDTO> GetAsync(Guid id);

        Task<RegionDTO> AddAsync(AddRegionRequest addRegionRequest);

        Task DeleteAsync(Guid id);

        Task<RegionDTO> UpdateAsync(Guid id, UpdateRegionRequest updateRegionRequest);
    }
}
