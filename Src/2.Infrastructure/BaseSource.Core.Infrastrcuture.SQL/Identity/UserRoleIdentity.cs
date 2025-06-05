using BaseSource.Core.Domain.Common.Aggregate;

namespace BaseSource.Core.Infrastrcuture.SQL.Identity;

[Table("UserRoles", Schema = "Identity")]
public class UserRoleIdentity : IdentityUserRole<long>, IEntity<long>
{
    public long Id { get; private set; }
    public EntityId EntityId { get; private set; } = Guid.NewGuid();
    public bool IsDefault { get; private set; }


    public UserRoleIdentity()
    {
        
    }
    public UserRoleIdentity(long userId, long roleId, bool isDefault)
    {
        UserId = userId;
        RoleId = roleId;
        IsDefault = isDefault;
    }
}
