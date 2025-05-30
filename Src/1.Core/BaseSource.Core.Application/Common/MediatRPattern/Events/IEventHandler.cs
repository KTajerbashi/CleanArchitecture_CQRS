using BaseSource.Core.Domain.Common.Event;

namespace BaseSource.Core.Application.Common.MediatRPattern.Events;

public interface IEventHandler<TEvent> : INotificationHandler<TEvent>
    where TEvent : IDomainEvent
{
}

public abstract class EventHandler<TEvent> : IEventHandler<TEvent>
    where TEvent : IDomainEvent
{
    public abstract Task Handle(TEvent notification, CancellationToken cancellationToken);
}