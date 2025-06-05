using BaseSource.Core.Domain.Common.Aggregate;

namespace BaseSource.Core.Infrastrcuture.SQL.Identity;

[Table("RoleClaims", Schema = "Identity")]
public class RoleClaimIdentity : IdentityRoleClaim<long>, IEntity<int>
{
    public EntityId EntityId { get; private set; } = Guid.NewGuid();

}
