using Walks.API.Models.DTOs;
using Walks.API.Models.DTOs.Requests;

namespace Walks.API.Services;

public interface IWalkDifficultyService
{
    Task<IList<WalkDifficulty>> GetAllAsync();
    Task<WalkDifficulty> GetAsync(Guid id);
    Task<WalkDifficulty> AddAsync(MutateWalkDifficultyRequest mutateWalkDifficultyRequest);
    Task DeleteAsync(Guid id);
    Task<WalkDifficulty> UpdateAsync(Guid id, MutateWalkDifficultyRequest mutateWalkDifficultyRequest);
}