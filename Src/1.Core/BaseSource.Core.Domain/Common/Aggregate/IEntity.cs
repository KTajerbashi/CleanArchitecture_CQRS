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
