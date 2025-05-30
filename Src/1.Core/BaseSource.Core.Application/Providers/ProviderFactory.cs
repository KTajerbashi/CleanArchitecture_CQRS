namespace BaseSource.Core.Application.Providers;

public class ProviderFactory
{
    public readonly IMediator Mediator;
    public readonly IPublisher Publisher;
    public readonly INotificationPublisher NotificationPublisher;
    public ProviderFactory(
        IMediator mediator, 
        IPublisher publisher, 
        INotificationPublisher notificationPublisher)
    {
        Mediator = mediator;
        Publisher = publisher;
        NotificationPublisher = notificationPublisher;
    }
}
