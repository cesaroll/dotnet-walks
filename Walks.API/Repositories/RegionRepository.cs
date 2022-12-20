using System;
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

    public IList<Region> GetAll()
    {
      return _dbContext.Regions.ToList();
    }
  }
}
