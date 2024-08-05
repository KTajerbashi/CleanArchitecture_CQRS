using Hangfire;

namespace AbstractionsExtensions.Library.BackgroundTask.HangfireProvider.Repositories
{
    public interface IBackgroudRepository
    {
        IBackgroundJobClient BackgroundJobClient { get; }
    }
}
