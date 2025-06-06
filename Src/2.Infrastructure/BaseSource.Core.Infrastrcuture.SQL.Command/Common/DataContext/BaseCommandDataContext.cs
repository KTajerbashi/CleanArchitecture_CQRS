using BaseSource.Core.Infrastrcuture.SQL.Command.Common.DataContext.Interceptors.ShadowProperties;
using BaseSource.Core.Infrastrcuture.SQL.DataContext;

namespace BaseSource.Core.Infrastrcuture.SQL.Command.Common.DataContext;

public abstract class BaseCommandDataContext : BaseDataContext
{
    protected BaseCommandDataContext()
    {
    }

    protected BaseCommandDataContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.AddAuditableShadowProperties<long>();
        builder.AddAuditableShadowProperties<int>();
        base.OnModelCreating(builder);

    }
}
