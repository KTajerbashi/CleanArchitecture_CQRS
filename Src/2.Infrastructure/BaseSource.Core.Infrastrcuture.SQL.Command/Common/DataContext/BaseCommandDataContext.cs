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
}
