namespace BaseSource.Infra.Data.Sql.Library.Databases;

public class BaseDatabaseContext : IdentityDbContext
{
    public BaseDatabaseContext(DbContextOptions options) : base(options) { }
    protected BaseDatabaseContext() { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
    }
}
