using System;
using Microsoft.EntityFrameworkCore;
using Walks.API.Data;
using Walks.API.Models.Domain;

namespace Walks.API.Repositories
{
  public class RegionRepository : IRegionRepository
  {
    private readonly WalksDbContext _dbContext;

    public RegionRepository(WalksDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<IList<Region>> GetAllAsync()
    {
      return await _dbContext.Regions.ToListAsync();
    }

    public async Task<Region> GetAsync(Guid id)
    {
      return await _dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<Region> AddAsync(Region region) {
      await _dbContext.AddAsync(region);
      await _dbContext.SaveChangesAsync();
      return region;
    }

    public async Task DeleteAsync(Guid id) {
      await _dbContext.Regions.Where(x => x.Id == id).ExecuteDeleteAsync();
    }

    public async Task<Region> UpdateAsync(Region region) {
      var existingRegion = await this.GetAsync(region.Id);

      if (existingRegion == null)
        return null;

      existingRegion.Code = region.Code;
      existingRegion.Name = region.Name;
      existingRegion.Area = region.Area;
      existingRegion.Lat = region.Lat;
      existingRegion.Long = region.Long;
      existingRegion.Population = region.Population;

      await _dbContext.SaveChangesAsync();
      return existingRegion;
    }
  }
}
