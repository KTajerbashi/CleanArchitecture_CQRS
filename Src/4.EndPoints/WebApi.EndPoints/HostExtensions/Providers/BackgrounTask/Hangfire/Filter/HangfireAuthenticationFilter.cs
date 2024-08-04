using Hangfire.Dashboard;

namespace WebApi.EndPoints.HostExtensions.Providers.BackgrounTask.Hangfire.Filter;

public class HangfireAuthenticationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context)
    {
        var httpContext = context.GetHttpContext();

        // Allow only authenticated users to see the Dashboard
        return httpContext.User.Identity.IsAuthenticated;
    }
}