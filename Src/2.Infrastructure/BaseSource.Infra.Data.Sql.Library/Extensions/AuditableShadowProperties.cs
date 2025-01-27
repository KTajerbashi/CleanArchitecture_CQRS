using BaseSource.Core.Application.Library.UseCases.Interfaces;
using BaseSource.Core.Domain.Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BaseSource.Infra.Data.Sql.Library.Extensions;


/// <summary>
/// فیلد های که در تمامی جداول میخواهیم وجود داشته باشد
/// </summary>
public static class AuditableShadowProperties
{
    public static readonly Func<object, string> EFPropertyCreatedByUserId =
                                    entity => EF.Property<string>(entity, CreatedByUserId);
    public static readonly string CreatedByUserId = nameof(CreatedByUserId);

    public static readonly Func<object, string> EFPropertyModifiedByUserId =
                                    entity => EF.Property<string>(entity, ModifiedByUserId);
    public static readonly string ModifiedByUserId = nameof(ModifiedByUserId);

    public static readonly Func<object, DateTime?> EFPropertyCreatedDateTime =
                                    entity => EF.Property<DateTime?>(entity, CreatedDateTime);
    public static readonly string CreatedDateTime = nameof(CreatedDateTime);

    public static readonly Func<object, DateTime?> EFPropertyModifiedDateTime =
                                    entity => EF.Property<DateTime?>(entity, ModifiedDateTime);
    public static readonly string ModifiedDateTime = nameof(ModifiedDateTime);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="modelBuilder"></param>
    public static void AddAuditableShadowProperties(this ModelBuilder modelBuilder)
    {
        /// تمامی کلاس های که اینترفس 
        /// IAuditableEntity
        /// را دارند را بگیر و پراپرتی های مورد نظر را به آنها اضافه کن
        /// و این فقط فبلد دیتابیس ساخته میشود
        foreach (var entityType in modelBuilder.Model.GetEntityTypes().Where(c => typeof(IAuditableEntity).IsAssignableFrom(c.ClrType)))
        {
            modelBuilder.Entity(entityType.ClrType)
                        .Property<string>(CreatedByUserId).HasMaxLength(50);
            modelBuilder.Entity(entityType.ClrType)
                        .Property<string>(ModifiedByUserId).HasMaxLength(50);
            modelBuilder.Entity(entityType.ClrType)
                        .Property<DateTime?>(CreatedDateTime);
            modelBuilder.Entity(entityType.ClrType)
                        .Property<DateTime?>(ModifiedDateTime);
        }
    }


    public static void SetAuditableEntityPropertyValues(
        this ChangeTracker changeTracker,
        IUser user)
    {

        var userAgent = user.GetUserAgent;
        var userIp = user.GetUserIp;
        var now = DateTime.UtcNow;
        var userId = user.UserIdOrDefault;

        var modifiedEntries = changeTracker.Entries<IAuditableEntity>().Where(x => x.State == EntityState.Modified);
        foreach (var modifiedEntry in modifiedEntries)
        {
            modifiedEntry.Property(ModifiedDateTime).CurrentValue = now;
            modifiedEntry.Property(ModifiedByUserId).CurrentValue = userId;
        }

        var addedEntries = changeTracker.Entries<IAuditableEntity>().Where(x => x.State == EntityState.Added);
        foreach (var addedEntry in addedEntries)
        {
            addedEntry.Property(CreatedDateTime).CurrentValue = now;
            addedEntry.Property(CreatedByUserId).CurrentValue = userId;
        }
    }

}

