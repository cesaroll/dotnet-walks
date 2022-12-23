using Walks.API.Models.Entities;

namespace Walks.API.Repositories;

public interface IWalkDifficultyRepository
{
    Task<IList<WalkDifficultyEntity>> GetAllAsync();
    Task<WalkDifficultyEntity> GetAsync(Guid id);
    Task<WalkDifficultyEntity> AddAsync(WalkDifficultyEntity walkDifficultyEntity);
    Task DeleteAsync(Guid id);
    Task<WalkDifficultyEntity> UpdateAsync(WalkDifficultyEntity walkDifficultyEntity);
}