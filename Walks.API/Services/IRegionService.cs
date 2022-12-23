using System;
using Walks.API.Models.DTOs;
using Walks.API.Models.DTOs.Requests;

namespace Walks.API.Services
{
    public interface IRegionService
    {
        Task<IList<Region>> GetAllAsync();

        Task<Region> GetAsync(Guid id);

        Task<Region> AddAsync(MutateRegionRequest mutateRegionRequest);

        Task DeleteAsync(Guid id);

        Task<Region> UpdateAsync(Guid id, MutateRegionRequest updateRegionRequest);
    }
}
