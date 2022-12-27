using Microsoft.EntityFrameworkCore;
using Walks.API.Models.Entities;

namespace Walks.API.Data;

public class WalksDbContext: DbContext
{
    public WalksDbContext(DbContextOptions<WalksDbContext> options): base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRoleEntity>()
            .HasOne(userRoleEntity => userRoleEntity.Role)
            .WithMany(roleEntity => roleEntity.UserRoles)
            .HasForeignKey(userRoleEntity => userRoleEntity.RoleId);
        
        modelBuilder.Entity<UserRoleEntity>()
            .HasOne(userRoleEntity => userRoleEntity.User)
            .WithMany(userEntity => userEntity.UserRoles)
            .HasForeignKey(userRoleEntity => userRoleEntity.UserId);
            
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<RegionEntity> Regions => Set<RegionEntity>();
    public DbSet<WalkEntity> Walks => Set<WalkEntity>();
    public DbSet<WalkDifficultyEntity> WalkDifficulties => Set<WalkDifficultyEntity>();
    public DbSet<UserEntity> Users => Set<UserEntity>();
    public DbSet<RoleEntity> Roles => Set<RoleEntity>();
    public DbSet<UserRoleEntity> UserRoles => Set<UserRoleEntity>();
}
