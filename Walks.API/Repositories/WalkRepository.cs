using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Walks.API.Data;
using Walks.API.Models.Entities;

namespace Walks.API.Repositories;

public class WalkRepository : IWalkRepository
{
    private readonly WalksDbContext _dbContext;
    private readonly DbSet<WalkEntity> _walks;

    public WalkRepository(WalksDbContext dbContext)
    {
        _dbContext = dbContext;
        _walks = _dbContext.Walks;
    }

    public async Task<IList<WalkEntity>> GetAllAsync()
    {
        return await _walks
            .Include(x => x.Region)
            .Include(x => x.WalkDifficulty)
            .ToListAsync();
    }

    public async Task<WalkEntity> GetAsync(Guid id)
    {
        var walkEntity = await _walks.FirstOrDefaultAsync(w => w.Id == id);

        if (walkEntity == null)
        {
            throw new ValidationException("Walk id was not found");
        }

        return walkEntity;
    }

    public async Task<WalkEntity> AddAsync(WalkEntity walkEntity)
    {
        var entry = await _walks.AddAsync(walkEntity);
        await _dbContext.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task DeleteAsync(Guid id)
    {
        await _walks.Where(w => w.Id == id).ExecuteDeleteAsync();
    }

    public async Task<WalkEntity> UpdateAsync(WalkEntity walkEntity)
    {
        var existingWalk = await this.GetAsync(walkEntity.Id);

        existingWalk.Name = walkEntity.Name;
        existingWalk.Length = walkEntity.Length;
        existingWalk.RegionId = walkEntity.RegionId;
        existingWalk.WalkDifficultyId = walkEntity.WalkDifficultyId;

        await _dbContext.SaveChangesAsync();
        return existingWalk;
    }
}