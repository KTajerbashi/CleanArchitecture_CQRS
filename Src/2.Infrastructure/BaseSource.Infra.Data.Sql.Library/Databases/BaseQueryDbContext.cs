using BaseSource.Core.Domain.Library.Entities.People.ValueObjects;

namespace BaseSource.Infra.Data.Sql.Library.Databases;

public abstract class BaseQueryDbContext : BaseDatabaseContext
{
    public BaseQueryDbContext(DbContextOptions options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    public override int SaveChanges() => throw new NotSupportedException();
    public override int SaveChanges(bool acceptAllChangesOnSuccess) => throw new NotSupportedException();
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default) => throw new NotSupportedException();
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
        configurationBuilder.Properties<BusinessId>().HaveConversion<BusinessIdConversion>();
        configurationBuilder.Properties<FirstName>().HaveConversion<FirstNameConversion>();
        configurationBuilder.Properties<LastName>().HaveConversion<LastNameConversion>();
        configurationBuilder.Properties<UserName>().HaveConversion<UserNameConversion>();
    }
    public override Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default) => throw new NotSupportedException();
}

