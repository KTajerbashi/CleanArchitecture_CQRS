using BaseSource.Core.Application.Common.UnitOfWorkPatter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BaseSource.Core.Infrastrcuture.SQL.Command.Common.UnitOfWorkPattern;

public abstract class UnitOfWork<TContext> : IUnitOfWork
    where TContext : BaseCommandDataContext
{
    protected readonly TContext _context;
    private IDbContextTransaction? _transaction;

    protected UnitOfWork(TContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    //public void BeginTransaction()
    //{
    //    _transaction = _context.Database.BeginTransaction();
    //}

    //public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    //{
    //    _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
    //}

    //public void CommitTransaction()
    //{
    //    try
    //    {
    //        _context.SaveChanges();
    //        _transaction?.Commit();
    //    }
    //    catch
    //    {
    //        RollbackTransaction();
    //        throw;
    //    }
    //    finally
    //    {
    //        DisposeTransaction();
    //    }
    //}

    //public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    //{
    //    var strategy = _context.Database.CreateExecutionStrategy();

    //    await strategy.ExecuteAsync(async () =>
    //    {
    //        // start the transaction INSIDE the strategy
    //        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
    //        try
    //        {
    //            await _context.SaveChangesAsync(cancellationToken);
    //            await transaction.CommitAsync(cancellationToken);
    //        }
    //        catch
    //        {
    //            await transaction.RollbackAsync(cancellationToken);
    //            throw;
    //        }
    //    });
    //}

    //public void RollbackTransaction()
    //{
    //    try
    //    {
    //        _transaction?.Rollback();
    //    }
    //    finally
    //    {
    //        DisposeTransaction();
    //    }
    //}

    //public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    //{
    //    try
    //    {
    //        if (_transaction != null)
    //            await _transaction.RollbackAsync(cancellationToken);
    //    }
    //    finally
    //    {
    //        await DisposeTransactionAsync();
    //    }
    //}

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        DisposeTransaction();
        _context.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeTransactionAsync();
        await _context.DisposeAsync();
    }

    private void DisposeTransaction()
    {
        _transaction?.Dispose();
        _transaction = null;
    }

    private async Task DisposeTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async Task TransactionAsync(Func<Task> func, CancellationToken cancellationToken = default)
    {
        var strategy = _context.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                await func.Invoke(); // execute your business logic
                await _context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        });
    }

    public async Task<TResult> TransactionAsync<TResult>(Func<Task<TResult>> func, CancellationToken cancellationToken = default)
    {
        var strategy = _context.Database.CreateExecutionStrategy();
        return await strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var result = await func.Invoke(); // get your return result
                await _context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
                return result;
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        });
    }
}