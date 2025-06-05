namespace BaseSource.Core.Application.Common.UnitOfWorkPatter;

public interface IUnitOfWork
{
    Task<int> SaveChangeAsync(CancellationToken cancellationToken = default);
    int SaveChange();

    void BeginTransaction();
    Task BeginTransactionAsync();

    void CommitTransaction();
    Task CommitTransactionAsync();

    void RollbackTransaction();
    Task RollbackTransactionAsync();
}
