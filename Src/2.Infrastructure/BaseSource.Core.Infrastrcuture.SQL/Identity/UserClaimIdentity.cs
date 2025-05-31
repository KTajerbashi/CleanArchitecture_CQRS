using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseSource.Core.Infrastrcuture.SQL.Identity;

[Table("UserClaims", Schema = "Identity")]
public class UserClaimIdentity : IdentityUserClaim<long>
{
}
