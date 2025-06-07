using BaseSource.Core.Infrastrcuture.SQL.Common.Conversions;

namespace BaseSource.Core.Infrastrcuture.SQL.DataContext;

public abstract class BaseDataContext : IdentityDbContext<UserIdentity, RoleIdentity, long, UserClaimIdentity, UserRoleIdentity, UserLoginIdentity, RoleClaimIdentity, UserTokenIdentity>
{
    protected BaseDataContext()
    {

    }

    protected BaseDataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
        configurationBuilder.Properties<EntityId>().HaveConversion<EntityIdConversion>();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyIdentityConfiguration();
    }

    public T GetShadowPropertyValue<T>(object entity, string propertyName) where T : IConvertible
    {
        var value = Entry(entity).Property(propertyName).CurrentValue;
        var condition = (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture)!;
        return value != null ? condition : default!;
    }
    public object GetShadowPropertyValue(object entity, string propertyName) => Entry(entity).Property(propertyName).CurrentValue!;

    
}
