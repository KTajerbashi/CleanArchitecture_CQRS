using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace AbstractionsExtensions.Library.BackgroundTask.HangfireProvider.Filters;

public class HangfireAuthenticationIdentityFilter : IDashboardAuthorizationFilter
{
    public bool Authorize([NotNull] DashboardContext context)
    {
        return context.GetHttpContext().User.Identity.IsAuthenticated;
    }
}
