using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BaseSource.Utilities.MapperProvider;

public static class DependencyInjection
{
    public static IServiceCollection AddAutoMapperProfiles(
        this IServiceCollection services, 
        IConfiguration configuration,
        Assembly[] assemblies)
    {
        services.AddAutoMapper(config =>
        {
        }, assemblies);

        services.AddSingleton<IMapperAdapter, MapperAdapter>();

        return services;
    }
}