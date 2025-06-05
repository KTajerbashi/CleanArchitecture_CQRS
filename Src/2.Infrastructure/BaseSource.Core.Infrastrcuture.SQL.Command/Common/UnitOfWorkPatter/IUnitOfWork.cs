using BaseSource.Core.Application.Common.UnitOfWorkPatter;

namespace BaseSource.Core.Infrastrcuture.SQL.Command.Common.UnitOfWorkPatter;

public abstract class UnitOfWork<TContext> : IUnitOfWork
    where TContext : BaseCommandDataContext
{
    protected readonly TContext Context;
    protected UnitOfWork(TContext context)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context), "Context cannot be null.");
    }

    public void BeginTransaction() => Context.Database.BeginTransaction();

    public async Task BeginTransactionAsync() => await Context.Database.BeginTransactionAsync();

    public void CommitTransaction() => Context.Database.CommitTransaction();

    public async Task CommitTransactionAsync() => await Context.Database.CommitTransactionAsync();

    public void RollbackTransaction() => Context.Database.RollbackTransaction();

    public async Task RollbackTransactionAsync() => await Context.Database.RollbackTransactionAsync();

    public int SaveChange() => Context.SaveChanges();

    public async Task<int> SaveChangeAsync(CancellationToken cancellationToken = default) => await Context.SaveChangesAsync(cancellationToken);
}
