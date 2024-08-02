namespace WebApi.EndPoints.HostExtensions.Identity;

public static class IdentityExtensions
{
    public static IServiceCollection AddIdentityService(this IServiceCollection services)
    {
        return services;
    }


    public static void UseIdentity(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}
