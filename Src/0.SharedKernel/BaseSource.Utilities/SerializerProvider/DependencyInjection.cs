using Microsoft.Extensions.DependencyInjection;

namespace BaseSource.Utilities.SerializerProvider;

public static class DependencyInjection
{
    public static IServiceCollection AddMicrosoftSerializer(this IServiceCollection services)
    => services.AddSingleton<IJsonSerializer, MicrosoftSerializer>();
}