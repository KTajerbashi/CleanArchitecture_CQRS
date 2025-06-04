using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseSource.Core.Infrastrcuture.SQL.Identity;

[Table("UserRoles", Schema = "Identity")]
public class UserRoleIdentity : IdentityUserRole<long>
{
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
