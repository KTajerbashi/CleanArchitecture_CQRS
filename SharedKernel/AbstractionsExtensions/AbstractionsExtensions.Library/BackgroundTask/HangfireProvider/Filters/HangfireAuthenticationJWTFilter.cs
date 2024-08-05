using AbstractionsExtensions.Library.BackgroundTask.HangfireProvider.Repositories;
using Hangfire.Dashboard;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AbstractionsExtensions.Library.BackgroundTask.HangfireProvider.Filters;
public class HangfireAuthenticationJWTFilter : IDashboardAuthorizationFilter
{
    private static readonly string HangFireCookieName = "HangFireCookie";

    private string role;
    public HangfireAuthenticationJWTFilter(string role = null)
    {
        this.role = role;
    }

    public bool Authorize(DashboardContext context)
    {
        var token = context.GetHttpContext().Request.Headers.Authorization;
        var httpContext = context.GetHttpContext();
        var jwtFactory = httpContext.RequestServices.GetService(typeof(IJwtFactory)) as IJwtFactory;

        var accessToken = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (string.IsNullOrEmpty(accessToken))
        {
            return false;
        }

        var principal = jwtFactory?.GetPrincipalFromToken(token);

        if (principal == null || !principal.Identity.IsAuthenticated)
        {
            return false;
        }

        if (!string.IsNullOrEmpty(role) && !principal.IsInRole(role))
        {
            return false;
        }

        return true;
    }

}