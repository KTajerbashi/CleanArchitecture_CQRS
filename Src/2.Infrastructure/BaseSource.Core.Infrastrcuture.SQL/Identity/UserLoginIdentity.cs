using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseSource.Core.Infrastrcuture.SQL.Identity;

[Table("UserLogins", Schema = "Identity")]
public class UserLoginIdentity : IdentityUserLogin<long>
{
}
