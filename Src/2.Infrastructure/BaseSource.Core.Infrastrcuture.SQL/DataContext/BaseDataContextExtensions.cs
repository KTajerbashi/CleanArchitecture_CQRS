namespace BaseSource.Core.Infrastrcuture.SQL.DataContext;

public static class BaseDataContextExtensions
{
    public static ModelBuilder ApplyIdentityConfiguration(this ModelBuilder builder)
    {
        builder.Entity<UserIdentity>().ToTable("Users", "Identity");

        builder.Entity<UserClaimIdentity>().ToTable("UserClaims", "Identity");

        builder.Entity<UserLoginIdentity>().ToTable("UserLogins", "Identity");

        builder.Entity<UserRoleIdentity>().ToTable("UserRoles", "Identity");

        builder.Entity<UserTokenIdentity>().ToTable("UserTokens", "Identity");

        builder.Entity<RoleIdentity>().ToTable("Roles", "Identity");

        builder.Entity<RoleClaimIdentity>().ToTable("RoleClaims", "Identity");
        return builder;
    }
}
