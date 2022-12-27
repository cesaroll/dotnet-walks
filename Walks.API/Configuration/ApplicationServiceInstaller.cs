using Walks.API.Repositories;
using Walks.API.Services;

namespace Walks.API.Configuration;

public class ApplicationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IRegionRepository, RegionRepository>();
        services.AddScoped<IRegionService, RegionService>();
        services.AddScoped<IWalkDifficultyRepository, WalkDifficultyRepository>();
        services.AddScoped<IWalkDifficultyService, WalkDifficultyService>();
        services.AddScoped<IWalkRepository, WalkRepository>();
        services.AddScoped<IWalkService, WalkService>();
        
     // services.AddSingleton<IUserRepository, MemoryUserRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITokenService, TokenService>();
        
        services.AddAutoMapper(typeof(Program).Assembly);
    }
}