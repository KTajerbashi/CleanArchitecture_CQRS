namespace BaseSource.Core.Domain.ValueObjects;

public class EntityId : BaseValueObject<EntityId>
{
    #region Properties
    public Guid Value { get; private set; }
    #endregion

    #region Constructors and Factories
    public static EntityId New() => new(Guid.NewGuid());

    public static EntityId FromGuid(Guid value) => new(value);

    public static EntityId FromString(string value)
    {
        if (!Guid.TryParse(value, out var guid))
        {
            throw new DomainValueObjectException("ValidationErrorInvalidGuid {0}", nameof(EntityId));
        }
        return new EntityId(guid);
    }

    private EntityId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new DomainValueObjectException("ValidationErrorGuidEmpty {0}", nameof(EntityId));
        }

        Value = value;
    }

    private EntityId() { }
    #endregion

    #region Equality Check
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    #endregion

    #region Operator Overloading
    public static explicit operator Guid(EntityId id) => id.Value;
    public static explicit operator string(EntityId id) => id.Value.ToString();
    public static implicit operator EntityId(Guid value) => new(value);
    #endregion

    #region Methods
    public override string ToString() => Value.ToString();
    #endregion
}


