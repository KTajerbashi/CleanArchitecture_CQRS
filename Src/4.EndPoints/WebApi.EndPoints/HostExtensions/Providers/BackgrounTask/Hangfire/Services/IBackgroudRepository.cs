using Hangfire;

namespace WebApi.EndPoints.HostExtensions.Providers.BackgrounTask.Hangfire.Services
{
    public interface IBackgroudRepository
    {
        IBackgroundJobClient BackgroundJobClient { get; }
    }
}
