using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureCQRS.CommandsDb.Library.BaseCommandInfrastrcture.Extensions;

public static class ModelCreatingExtension
{
    public static ModelBuilder ConfigurationTables(this ModelBuilder builder)
    {
        builder.Entity<IdentityUser>().ToTable("Users", "Security");
        builder.Entity<IdentityRole>().ToTable("Roles", "Security");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "Security");
        builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "Security");
        builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "Security");
        builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "Security");
        builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "Security");
        return builder;
    }
    public static ModelBuilder Seed(this ModelBuilder builder)
    {

        return builder;
    }
}
