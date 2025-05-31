using BaseSource.Utilities.SerializerProvider;
using Microsoft.Extensions.DependencyInjection;

namespace BaseSource.Utilities;

public static class DependencyInjections
{
    public static IServiceCollection AddBaseSourceUtilities(this IServiceCollection services)
    {
        services.AddMicrosoftSerializer();

        return services;
    }
}
