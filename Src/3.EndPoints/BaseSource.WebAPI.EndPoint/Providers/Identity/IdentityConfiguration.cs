using BaseSource.Core.Domain.Aggregates.Identity.RoleAggregate;
using BaseSource.Core.Infrastrcuture.SQL.Command.DataContext;
using BaseSource.Core.Infrastrcuture.SQL.Identity;
using Microsoft.AspNetCore.Identity;

namespace BaseSource.WebAPI.EndPoint.Providers.Identity;
public static class IdentityConfiguration
{
    public static IServiceCollection AddIdentityProviders(this IServiceCollection services)
    {
        services.AddIdentity<UserIdentity, RoleIdentity>(options =>
        {
            options.Password.RequiredLength = 6;
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = false;

            // Lockout settings
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            // User settings
            options.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<CommandDataContext>()
        .AddRoles<RoleIdentity>()
        .AddDefaultTokenProviders()
        .AddApiEndpoints();
        return services;
    }
}
