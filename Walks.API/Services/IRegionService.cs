using System;
using Walks.API.Models.DTO;

namespace Walks.API.Services
{
    public interface IRegionService
    {
        Task<IList<RegionDTO>> GetAllAsync();

        Task<RegionDTO> GetAsync(Guid id);
    }
}
