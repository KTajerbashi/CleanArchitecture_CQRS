using System.Linq.Expressions;

namespace BaseSource.Core.Infrastrcuture.SQL.Command.Common.DataContext.Interceptors.ShadowProperties;

public static class AuditableShadowExtensions
{
    public static ModelBuilder AddShadowProperty(this ModelBuilder modelBuilder)
    {
        //
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var builder = modelBuilder.Entity(entityType.ClrType);

            // Add shadow properties
            builder.Property<bool>("IsActive").HasDefaultValue(true);
            builder.Property<string>("IsDeleted").HasDefaultValue("No");

            builder.Property<long>("CreatedByUserRoleId");
            builder.Property<long?>("UpdatedByUserRoleId");

            builder.Property<DateTime>("CreatedDate");
            builder.Property<DateTime?>("UpdatedDate");
        }

        //
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(IAuditableEntity<long>).IsAssignableFrom(entityType.ClrType))
            {
                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var prop = Expression.Call(
            typeof(EF),
            nameof(EF.Property),
            new[] { typeof(bool) },
            parameter,
            Expression.Constant(AuditableShadowProperties.IsDeleted));

                var filter = Expression.Lambda(
            Expression.Equal(prop, Expression.Constant(false)),
            parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);
            }
        }
        return modelBuilder;
    }
}
