namespace BaseSource.Core.Domain.Common.Aggregate;

public interface IEntity<TId>
{
    TId Id { get; }
    EntityId EntityId { get; }
}

public interface IAuditableEntity<TId> : IEntity<TId>
{
    bool IsActive { get; }
    bool IsDeleted { get; }

}
public abstract class AuditableEntity<TId> : IAuditableEntity<TId>
    where TId : struct, IComparable, IComparable<TId>, IConvertible, IEquatable<TId>, IFormattable
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public TId Id { get; protected set; } = default;

    public EntityId EntityId { get; protected set; } = EntityId.New();

    public bool IsActive { protected set; get; }

    public bool IsDeleted { protected set; get; }
}
public abstract class Entity<TId> : AuditableEntity<TId>
    where TId : struct, IComparable, IComparable<TId>, IConvertible, IEquatable<TId>, IFormattable
{
    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType()) return false;
        var other = (Entity<TId>)obj;
        return Id.Equals(other.Id);
    }

    public override int GetHashCode() => Id.GetHashCode();

    public void Delete()
    {
        IsActive = false;
        IsDeleted = true;
    }

    public void Active()
    {
        IsActive = true;
        IsDeleted = false;
    }
}

public abstract class Entity : Entity<long>
{

}
public abstract class AggregateRoot<TId> : Entity<TId>
    where TId : struct, IComparable, IComparable<TId>, IConvertible, IEquatable<TId>, IFormattable
{
    private readonly List<IDomainEvent> _events = new();
    public void AddEvent(IDomainEvent @event) => _events.Add(@event);
    public void CleanEvents() => _events.Clear();
    public IEnumerable<IDomainEvent> GetEvents() => _events.AsEnumerable();
    public IReadOnlyCollection<IDomainEvent> Events => _events;

    protected AggregateRoot() => _events = new();


    private void Mutate(IDomainEvent @event)
    {
        var onMethod = this.GetType().GetMethod("On", BindingFlags.Instance | BindingFlags.NonPublic, [@event.GetType()]);
        onMethod.Invoke(this, new[] { @event });
    }
    protected void Apply(IDomainEvent @event)
    {
        Mutate(@event);
        AddEvent(@event);
    }
    public AggregateRoot(IEnumerable<IDomainEvent> events)
    {
        if (events == null || !events.Any()) return;
        foreach (var @event in events)
        {
            Mutate(@event);
        }
    }
}

public abstract class AggregateRoot : AggregateRoot<long>
{

}