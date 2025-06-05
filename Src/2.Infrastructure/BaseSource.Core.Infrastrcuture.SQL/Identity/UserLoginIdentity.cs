using BaseSource.Core.Domain.Common.Aggregate;

namespace BaseSource.Core.Infrastrcuture.SQL.Identity;

[Table("UserLogins", Schema = "Identity")]
public class UserLoginIdentity : IdentityUserLogin<long>, IEntity<long>
{
    public long Id { get; private set; }
    public EntityId EntityId { get; private set; } = Guid.NewGuid();
}
