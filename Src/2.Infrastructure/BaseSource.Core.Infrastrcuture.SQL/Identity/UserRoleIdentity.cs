using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseSource.Core.Infrastrcuture.SQL.Identity;

[Table("UserRoles", Schema = "Identity")]
public class UserRoleIdentity : IdentityUserRole<long>
{
}
