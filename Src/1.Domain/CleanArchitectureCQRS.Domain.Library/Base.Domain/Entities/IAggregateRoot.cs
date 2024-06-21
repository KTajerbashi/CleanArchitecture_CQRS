using CleanArchitectureCQRS.Domain.Library.Base.Domain.Events;


namespace CleanArchitectureCQRS.Domain.Library.Base.Domain.Entities;

/// <summary>
/// Interface for AggregateRoot
/// IAggregateRoot is the combination of IBaseEntity and IAggregateRoot
/// </summary>
/// <typeparam name="TKey"></typeparam>
public interface IAggregateRoot<out TKey> : IBaseEntity<TKey>
{
    long Version { get; }
    IReadOnlyCollection<IDomainEvent<TKey>> Events { get; }
    void ClearEvents();
}
