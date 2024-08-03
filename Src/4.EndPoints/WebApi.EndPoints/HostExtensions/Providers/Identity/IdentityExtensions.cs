﻿using CleanArchitectureCQRS.CommandsDb.Library.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApi.EndPoints.HostExtensions.Providers.Identity.Repositories;
using WebApi.EndPoints.HostExtensions.Providers.Identity.Services;

namespace WebApi.EndPoints.HostExtensions.Providers.Identity;

public static class IdentityExtensions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        => services
        .AddIdentity()
        .AddIdentityJWT(configuration)
        .AddIdentityConfigs()
        .AddIdentityCookies()
        .AddIdentityPolicies();
    private static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services.AddIdentity<IdentityUser, IdentityRole>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<DbContextApplicationCommand>()
            .AddDefaultTokenProviders()
            //.AddSignInManager()
            //.AddUserManager()
            //.AddRoleManager<IdentityRole>()
            ;

        return services;

    }
    private static IServiceCollection AddIdentityConfigs(this IServiceCollection services)
    {
        services.Configure<IdentityOptions>(options =>
        {
            // Password settings.
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;

            // Lockout settings.
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            // User settings.
            options.User.AllowedUserNameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = false;
        });
        return services;
    }

    private static IServiceCollection AddIdentityCookies(this IServiceCollection services)
    {
        services.ConfigureApplicationCookie(options =>
        {
            // Cookie settings
            options.Cookie.HttpOnly = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

            options.LoginPath = "/Identity/Account/Login";
            options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            options.SlidingExpiration = true;
        });
        return services;
    }
    private static IServiceCollection AddIdentityPolicies(this IServiceCollection services)
    {

        return services;
    }

    private static IServiceCollection AddIdentityJWT(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
            };
        });
        services.AddAuthorization();
        services.AddScoped<IJWTServiceToken, JWTServiceToken>();
        return services;
    }
    public static void UseIdentity(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}
