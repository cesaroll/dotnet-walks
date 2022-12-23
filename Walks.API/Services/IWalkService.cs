using System;
using Walks.API.Models.DTOs;
using Walks.API.Models.DTOs.Requests;

namespace Walks.API.Services
{
    public interface IWalkService
    {
        Task<IList<Walk>> GetAllAsync();
        Task<Walk> GetAsync(Guid id);
        Task<Walk> AddAsync(MutateWalkRequest mutateWalkRequest);
        Task DeleteAsync(Guid id);
        Task<Walk> UpdateAsync(Guid id, MutateWalkRequest mutateWalkRequest);
    }
}
