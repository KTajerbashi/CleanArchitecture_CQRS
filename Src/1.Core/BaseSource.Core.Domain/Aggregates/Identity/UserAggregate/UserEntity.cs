using BaseSource.Core.Domain.Common.Aggregate;
using static BaseSource.Core.Domain.Aggregates.Identity.UserAggregate.Parameters.UserParameters;

namespace BaseSource.Core.Domain.Aggregates.Identity.UserAggregate;

[Table("Users", Schema = "Identity")]
public class UserEntity : Entity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string NationalCode { get; private set; }
    public string UserName { get; private set; }
    public string NormalizedUserName { get; private set; }
    public string Email { get; private set; }
    public string NormalizedEmail { get; private set; }
    public bool EmailConfirmed { get; private set; }
    public string PasswordHash { get; private set; }
    public string SecurityStamp { get; private set; }
    public string ConcurrencyStamp { get; private set; }
    public string PhoneNumber { get; private set; }
    public bool PhoneNumberConfirmed { get; private set; }
    public bool TwoFactorEnabled { get; private set; }
    public DateTimeOffset? LockoutEnd { get; private set; }
    public bool LockoutEnabled { get; private set; }
    public int AccessFailedCount { get; private set; }

    private UserEntity() { }

    public UserEntity(UserParameter parameter)
    {
        FirstName = parameter.FirstName;
        LastName = parameter.LastName;
        NationalCode = parameter.NationalCode;
        UserName = parameter.UserName;
        Email = parameter.Email;
        PhoneNumber = parameter.PhoneNumber;
    }

    public static UserEntity MapModel(UserModelParameter parameter)
    {
        return new UserEntity()
        {
            Id = parameter.Id,
            EntityId = parameter.EntityId,
            FirstName = parameter.FirstName,
            LastName = parameter.LastName,
            NationalCode = parameter.NationalCode,
            UserName = parameter.UserName,
            NormalizedUserName = parameter.NormalizedUserName,
            Email = parameter.Email,
            NormalizedEmail = parameter.NormalizedEmail,
            EmailConfirmed = parameter.EmailConfirmed,
            PasswordHash = parameter.PasswordHash,
            SecurityStamp = parameter.SecurityStamp,
            ConcurrencyStamp = parameter.ConcurrencyStamp,
            PhoneNumber = parameter.PhoneNumber,
            PhoneNumberConfirmed = parameter.PhoneNumberConfirmed,
            TwoFactorEnabled = parameter.TwoFactorEnabled,
            LockoutEnd = parameter.LockoutEnd,
            LockoutEnabled = parameter.LockoutEnabled,
            AccessFailedCount = parameter.AccessFailedCount,
        };
    }

}

