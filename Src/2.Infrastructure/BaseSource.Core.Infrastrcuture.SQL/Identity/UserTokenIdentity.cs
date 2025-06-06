using BaseSource.Core.Domain.Common.Aggregate;

namespace BaseSource.Core.Infrastrcuture.SQL.Identity;

[Table("UserTokens", Schema = "Identity")]
public class UserTokenIdentity : IdentityUserToken<long>, IAuditableEntity<long>
{
    public long Id { get; private set; }
    public EntityId EntityId { get; private set; } = Guid.NewGuid();

    public bool IsDeleted { get; private set; }
    public bool IsActive { get; private set; }
}
