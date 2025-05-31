using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseSource.Core.Infrastrcuture.SQL.Identity;

[Table("Users", Schema = "Identity")]
public class UserIdentity : IdentityUser<long>
{
}
