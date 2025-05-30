

namespace BaseSource.Core.Domain.Common.Event;

public interface IDomainEvent : INotification
{
    DateTime OccurredOn { get; }
}

public abstract class DomainEvent : IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.Now;
}