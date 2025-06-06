using BaseSource.Core.Domain.Common.Aggregate;
using BaseSource.Core.Infrastrcuture.SQL.Identity.Parameters;

namespace BaseSource.Core.Infrastrcuture.SQL.Identity;

[Table("Users", Schema = "Identity")]
public class UserIdentity : IdentityUser<long>, IAuditableEntity<long>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string NationalCode { get; private set; }
    public bool IsDeleted { get; private set; }
    public bool IsActive { get; private set; }
    public EntityId EntityId { get; private set; } = Guid.NewGuid();

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
