namespace BaseSource.Core.Infrastrcuture.SQL.Command.DataContext;

public class CommandDataContext : BaseCommandDataContext
{
    public CommandDataContext()
    {
    }

    public CommandDataContext(DbContextOptions<CommandDataContext> options) : base(options)
    {
    }
}
