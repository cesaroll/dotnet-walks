using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Walks.API.Data;
using Walks.API.Models.Entities;

namespace Walks.API.Repositories;

public class WalkDifficultyRepository : IWalkDifficultyRepository
{
    private readonly WalksDbContext _walksDbContext;
    private readonly DbSet<WalkDifficultyEntity> _walkDifficulties;

    public WalkDifficultyRepository(WalksDbContext walksDbContext)
    {
        _walksDbContext = walksDbContext;
        _walkDifficulties = walksDbContext.WalkDifficulties;
    }

    public async Task<IList<WalkDifficultyEntity>> GetAllAsync()
    {
        return await _walkDifficulties.ToListAsync();
    }

    public async Task<WalkDifficultyEntity> GetAsync(Guid id)
    {
        var walkDifficulty = await _walkDifficulties.FirstOrDefaultAsync(x => x.Id == id);

        if (walkDifficulty == null)
        {
            throw new ValidationException("Walk difficulty id was not found");
        }

        return walkDifficulty;
    }

    public async Task<WalkDifficultyEntity> AddAsync(WalkDifficultyEntity walkDifficultyEntity)
    {
        var entry = await _walkDifficulties.AddAsync(walkDifficultyEntity);
        await _walksDbContext.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task DeleteAsync(Guid id)
    {
        await _walkDifficulties.Where(x => x.Id == id).ExecuteDeleteAsync();
    }

    public async Task<WalkDifficultyEntity> UpdateAsync(WalkDifficultyEntity walkDifficultyEntity)
    {
        var existingWalkDifficultityEntity = await this.GetAsync(walkDifficultyEntity.Id);

        existingWalkDifficultityEntity.Code = walkDifficultyEntity.Code;

        await _walksDbContext.SaveChangesAsync();
        return existingWalkDifficultityEntity;
    }
}