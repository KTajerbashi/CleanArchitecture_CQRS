namespace CleanArchitectureCQRS.Domain.Library.Base.Domain.Events;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TKey"></typeparam>
public interface IDomainEvent<out TKey>
{
    public long AggregateVersion { get; }
    TKey AggregateId { get; }
    DateTime TimeStamp { get; }
}
