using Microsoft.EntityFrameworkCore;
using Walks.API.Models.Entities;

namespace Walks.API.Data;

public class WalksDbContext: DbContext
{
    public WalksDbContext(DbContextOptions<WalksDbContext> options): base(options)
    {
    }

    public DbSet<RegionEntity> Regions => Set<RegionEntity>();
    public DbSet<WalkEntity> Walks => Set<WalkEntity>();
    public DbSet<WalkDifficultyEntity> WalkDifficulties => Set<WalkDifficultyEntity>();
}
