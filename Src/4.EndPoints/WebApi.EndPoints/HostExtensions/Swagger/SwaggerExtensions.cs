using Microsoft.OpenApi.Models;

namespace WebApi.EndPoints.HostExtensions.Swagger;

public static class SwaggerExtensions
{
    public static IServiceCollection SwaggerService(this IServiceCollection services, IConfiguration configuration, string sectionName)
    {
        services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "CleanArchitecture_CQRS",
                Version = "v1",
                Description = "CleanArchitecture_CQRS Application",
                License = new OpenApiLicense
                {
                    Name = "License",
                    Url = new Uri("https://google.com")
                },
                Contact = new OpenApiContact
                {
                    Name = "Tajerbashi",
                    Email = "Tajerbashi@mail.com",
                    Url = new Uri("https://github.com/KTajerbashi")
                },
                TermsOfService = new Uri("https://github.com/KTajerbashi/CleanArchitecture_CQRS")
            });
            option.AddSecurityDefinition("JWT", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
                BearerFormat = "text",
                In = ParameterLocation.Header,
                Flows = new OpenApiOAuthFlows
                {
                    AuthorizationCode = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri("https://github.com/KTajerbashi"),
                        TokenUrl = new Uri("https://github.com/KTajerbashi"),
                    },
                    ClientCredentials = new OpenApiOAuthFlow { }
                },
                OpenIdConnectUrl = new Uri("https://github.com/KTajerbashi"),
                Scheme = "Bearer",
                Type = SecuritySchemeType.ApiKey,
                UnresolvedReference = true,
            });
  
        });
        return services;
    }
    public static void UseSwaggerUI(this WebApplication app, string sectionName)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanArchitecture_CQRS V1 ");
        });
    }
}
