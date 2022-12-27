using Microsoft.EntityFrameworkCore;
using Walks.API.Data;

namespace Walks.API.Configuration;

public class InfrastructureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<WalksDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Walks"));
        });
    }
}