using FluentValidation.AspNetCore;

namespace Walks.API.Configuration;

public class ValidationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();
    }
}