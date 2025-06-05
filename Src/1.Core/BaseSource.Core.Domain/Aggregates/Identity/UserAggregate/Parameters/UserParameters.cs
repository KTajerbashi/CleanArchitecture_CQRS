namespace BaseSource.Core.Domain.Aggregates.Identity.UserAggregate.Parameters;

public class UserParameters
{
    public record UserParameter(
        string FirstName,
        string LastName,
        string NationalCode,
        string UserName,
        string Email,
        string PhoneNumber
        );

    public record UserModelParameter(
        long Id,
        Guid EntityId,
        string FirstName,
        string LastName,
        string NationalCode,
        string UserName,
        string NormalizedUserName,
        string Email,
        string NormalizedEmail,
        bool EmailConfirmed,
        string PasswordHash,
        string SecurityStamp,
        string ConcurrencyStamp,
        string PhoneNumber,
        bool PhoneNumberConfirmed,
        bool TwoFactorEnabled,
        DateTimeOffset? LockoutEnd,
        bool LockoutEnabled,
        int AccessFailedCount
        );
}
