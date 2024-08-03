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
        var adminRole = new IdentityRole{Id=Guid.NewGuid().ToString(),Name = "Admin",NormalizedName="Admin".ToUpper(),ConcurrencyStamp=Guid.NewGuid().ToString("D")};
        var normalRole = new IdentityRole{Id=Guid.NewGuid().ToString(),Name = "User",NormalizedName="User".ToUpper(),ConcurrencyStamp=Guid.NewGuid().ToString("D")};

        var hasher = new PasswordHasher<IdentityUser>();

        var adminUser = new IdentityUser
        {
            Id = Guid.NewGuid().ToString(),
            Email = "Admin@mail.com",
            UserName="Admin@mail.com",
            ConcurrencyStamp=Guid.NewGuid().ToString("D"),
            PasswordHash=hasher.HashPassword(null,"@Admin#123"),
            NormalizedEmail = "Admin@mail.com".ToUpper(),
            NormalizedUserName = "Admin@mail.com".ToUpper(),
            SecurityStamp=Guid.NewGuid().ToString("D"),
            AccessFailedCount=0,
            LockoutEnabled=false,
            EmailConfirmed=false,
            PhoneNumber="09011001000",
            PhoneNumberConfirmed=false,
            TwoFactorEnabled=false,
        };
        var normalUser = new IdentityUser
        {
            Id = Guid.NewGuid().ToString(),
            Email = "User@mail.com",
            UserName="User@mail.com",
            ConcurrencyStamp=Guid.NewGuid().ToString("D"),
            PasswordHash=hasher.HashPassword(null,"@User#123"),
            NormalizedEmail = "User@mail.com".ToUpper(),
            NormalizedUserName = "User@mail.com".ToUpper(),
            SecurityStamp=Guid.NewGuid().ToString("D"),
            AccessFailedCount=0,
            LockoutEnabled=false,
            EmailConfirmed=false,
            PhoneNumber="09011001001",
            PhoneNumberConfirmed=false,
            TwoFactorEnabled=false,
        };

        builder.Entity<IdentityRole>().HasData(adminRole, normalRole);
        builder.Entity<IdentityUser>().HasData(adminUser, normalUser);
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { RoleId = adminRole.Id, UserId = adminUser.Id },
            new IdentityUserRole<string> { RoleId = normalRole.Id, UserId = normalUser.Id }
            );

        return builder;
    }
}
