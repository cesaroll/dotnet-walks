using System;
using Microsoft.EntityFrameworkCore;
using Walks.API.Data;
using Walks.API.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Walks.API.Repositories
{
  public class RegionRepository : IRegionRepository
  {
    private readonly WalksDbContext _dbContext;

    public RegionRepository(WalksDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<IList<RegionEntity>> GetAllAsync()
    {
      return await _dbContext.Regions.ToListAsync();
    }

    public async Task<RegionEntity> GetAsync(Guid id)
    {
      var regionEntity = await _dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);

      if (regionEntity == null) {
        throw new ValidationException("Region id was not found");
      }

      return regionEntity;
    }

    public async Task<RegionEntity> AddAsync(RegionEntity regionEntity) {
      var entry = await _dbContext.AddAsync(regionEntity);
      await _dbContext.SaveChangesAsync();
      return entry.Entity;
    }

    public async Task DeleteAsync(Guid id) {
      await _dbContext.Regions.Where(x => x.Id == id).ExecuteDeleteAsync();
    }

    public async Task<RegionEntity> UpdateAsync(RegionEntity regionEntity) {
      var existingRegion = await this.GetAsync(regionEntity.Id);
      
      existingRegion.Code = regionEntity.Code;
      existingRegion.Name = regionEntity.Name;
      existingRegion.Area = regionEntity.Area;
      existingRegion.Lat = regionEntity.Lat;
      existingRegion.Long = regionEntity.Long;
      existingRegion.Population = regionEntity.Population;

      await _dbContext.SaveChangesAsync();
      return existingRegion;
    }
  }
}
