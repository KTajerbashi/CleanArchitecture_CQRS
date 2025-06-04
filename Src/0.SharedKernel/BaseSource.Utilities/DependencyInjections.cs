using BaseSource.Utilities.CacheProvider;
using BaseSource.Utilities.MapperProvider;
using System.Reflection;

namespace BaseSource.Utilities;

public static class DependencyInjections
{
    public static IServiceCollection AddBaseSourceUtilities(this IServiceCollection services, IConfiguration configuration, Assembly[] assemblies)
    {
        services.AddMicrosoftSerializer();
        
        services.AddQueryExecute(configuration);
        
        services.AddScrutorProvider();

        services.AddAutoMapperProfiles(configuration, assemblies);

        services.AddSqlDistributedCache(configuration, "SqlCache");

        return services;
    }
}
