using BaseSource.Core.Infrastrcuture.SQL.Identity.Parameters;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseSource.Core.Infrastrcuture.SQL.Identity;

[Table("Users", Schema = "Identity")]
public class UserIdentity : IdentityUser<long>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string NationalCode { get; private set; }
    public UserIdentity()
    {

    }
    public UserIdentity(UserCreateParameters parameters)
    {
        UserName = parameters.UserName;
        Email = parameters.Email;
        FirstName = parameters.FirstName;
        LastName = parameters.LastName;
        PhoneNumber = parameters.PhoneNumber;
        NationalCode = parameters.NationalCode;
    }
}
