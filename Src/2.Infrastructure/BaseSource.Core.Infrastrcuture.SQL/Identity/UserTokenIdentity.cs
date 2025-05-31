using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseSource.Core.Infrastrcuture.SQL.Identity;

[Table("UserTokens", Schema = "Identity")]
public class UserTokenIdentity : IdentityUserToken<long>
{
}
