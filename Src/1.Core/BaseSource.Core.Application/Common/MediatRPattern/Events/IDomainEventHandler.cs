using BaseSource.Core.Domain.Common.Event;

namespace BaseSource.Core.Application.Common.MediatRPattern.Events;

public interface IDomainEventHandler<TEvent> : INotificationHandler<TEvent>
    where TEvent : IDomainEvent
{
}

public abstract class DomainEventHandler<TEvent> : IDomainEventHandler<TEvent>
    where TEvent : IDomainEvent
{
    protected readonly ProviderFactory ProviderFactory;
    protected DomainEventHandler(ProviderFactory providerFactory)
    {
        ProviderFactory = providerFactory;
    }
    public abstract Task Handle(TEvent notification, CancellationToken cancellationToken);
}