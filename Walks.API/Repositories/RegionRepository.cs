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
  }
}
