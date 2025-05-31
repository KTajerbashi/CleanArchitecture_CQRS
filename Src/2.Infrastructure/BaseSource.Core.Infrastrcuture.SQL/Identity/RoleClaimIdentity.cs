using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseSource.Core.Infrastrcuture.SQL.Identity;

[Table("RoleClaims", Schema = "Identity")]
public class RoleClaimIdentity : IdentityRoleClaim<long>
{
}
