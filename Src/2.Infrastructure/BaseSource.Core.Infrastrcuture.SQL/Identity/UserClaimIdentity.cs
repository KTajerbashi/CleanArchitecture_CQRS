using BaseSource.Core.Domain.Common.Aggregate;

namespace BaseSource.Core.Infrastrcuture.SQL.Identity;

[Table("UserClaims", Schema = "Identity")]
public class UserClaimIdentity : IdentityUserClaim<long>, IEntity<int>
{
    public EntityId EntityId { get; private set; } = Guid.NewGuid();
}
