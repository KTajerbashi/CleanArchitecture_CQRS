using BaseSource.Core.Domain.Library.Aggregates.People.ValueObjects;
using BaseSource.Core.Domain.Library.ValueObjects;
using BaseSource.Infra.Data.Sql.Library.ValueConversions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BaseSource.Infra.Data.Sql.Library.Databases;

/// <summary>
/// 
/// </summary>
public abstract class BaseQueryDbContext : BaseDatabaseContext
{
    public BaseQueryDbContext(DbContextOptions options) : base(options) { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    /// <summary>
    /// نباید نوشتن کار کند
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public override int SaveChanges()
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// نباید نوشتن کار کند
    /// </summary>
    /// <param name="acceptAllChangesOnSuccess"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        throw new NotSupportedException();

    }


    /// <summary>
    /// نباید نوشتن کار کند
    /// </summary>
    /// <param name="acceptAllChangesOnSuccess"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        throw new NotSupportedException();

    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
        configurationBuilder.Properties<BusinessId>().HaveConversion<BusinessIdConversion>();
        configurationBuilder.Properties<FirstName>().HaveConversion<FirstNameConversion>();
        configurationBuilder.Properties<LastName>().HaveConversion<LastNameConversion>();
        configurationBuilder.Properties<UserName>().HaveConversion<UserNameConversion>();

    }


    /// <summary>
    /// نباید نوشتن کار کند
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotSupportedException();

    }
}

