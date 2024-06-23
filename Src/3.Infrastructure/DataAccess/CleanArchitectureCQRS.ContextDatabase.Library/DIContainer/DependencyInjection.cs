using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureCQRS.ContextDatabase.Library.DIContainer;

public static class DependencyInjection
{
    public static IServiceCollection AddContextDatabaseDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}