using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseSource.Core.Infrastrcuture.SQL.Identity;

[Table("Roles", Schema = "Identity")]
public class RoleIdentity : IdentityRole<long>
{
}
