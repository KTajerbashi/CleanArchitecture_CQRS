using BaseSource.Core.Application.Common.UnitOfWorkPatter;
using Microsoft.EntityFrameworkCore.Storage;

namespace BaseSource.Core.Infrastrcuture.SQL.Command.Common.UnitOfWorkPatter;

public abstract class UnitOfWork<TContext> : IUnitOfWork, IAsyncDisposable
    where TContext : BaseCommandDataContext
{
    private readonly TContext _context;
    private IDbContextTransaction _currentTransaction;
    private bool _disposed;

    protected UnitOfWork(TContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public bool HasActiveTransaction => _currentTransaction != null;

    public void BeginTransaction()
    {
        if (HasActiveTransaction)
        {
            throw new CommandTransactionException("A transaction is already in progress.");
        }

        _currentTransaction = _context.Database.BeginTransaction();
    }

    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (HasActiveTransaction)
        {
            throw new CommandTransactionException("A transaction is already in progress.");
        }

        _currentTransaction = await _context.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task BeginTransactionWithoutRetryAsync(CancellationToken cancellationToken = default)
    {
        if (HasActiveTransaction)
        {
            throw new CommandTransactionException("A transaction is already in progress.");
        }

        var strategy = _context.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            _currentTransaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        });
    }

    public void CommitTransaction()
    {
        if (!HasActiveTransaction)
        {
            throw new CommandTransactionException("No active transaction to commit.");
        }

        try
        {
            _currentTransaction.Commit();
        }
        catch
        {
            RollbackTransaction();
            throw;
        }
        finally
        {
            _currentTransaction?.Dispose();
            _currentTransaction = null;
        }
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (!HasActiveTransaction)
        {
            throw new CommandTransactionException("No active transaction to commit.");
        }

        try
        {
            await _currentTransaction.CommitAsync(cancellationToken);
        }
        catch
        {
            await RollbackTransactionAsync(cancellationToken);
            throw;
        }
        finally
        {
            if (_currentTransaction != null)
            {
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
        }
    }

    public async Task CommitTransactionWithoutRetryAsync(CancellationToken cancellationToken = default)
    {
        if (!HasActiveTransaction)
        {
            throw new CommandTransactionException("No active transaction to commit.");
        }

        var strategy = _context.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            try
            {
                await _currentTransaction.CommitAsync(cancellationToken);
            }
            catch
            {
                await RollbackTransactionAsync(cancellationToken);
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    await _currentTransaction.DisposeAsync();
                    _currentTransaction = null;
                }
            }
        });
    }

    public void RollbackTransaction()
    {
        if (!HasActiveTransaction)
        {
            throw new CommandTransactionException("No active transaction to rollback.");
        }

        try
        {
            _currentTransaction.Rollback();
        }
        finally
        {
            _currentTransaction?.Dispose();
            _currentTransaction = null;
        }
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (!HasActiveTransaction)
        {
            throw new CommandTransactionException("No active transaction to rollback.");
        }

        try
        {
            await _currentTransaction.RollbackAsync(cancellationToken);
        }
        finally
        {
            if (_currentTransaction != null)
            {
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
        }
    }

    public async Task RollbackTransactionWithoutRetryAsync(CancellationToken cancellationToken = default)
    {
        if (!HasActiveTransaction)
        {
            throw new CommandTransactionException("No active transaction to rollback.");
        }

        var strategy = _context.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            try
            {
                await _currentTransaction.RollbackAsync(cancellationToken);
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    await _currentTransaction.DisposeAsync();
                    _currentTransaction = null;
                }
            }
        });
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore().ConfigureAwait(false);
        Dispose(false);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _currentTransaction?.Dispose();
                _context?.Dispose();
            }
            _disposed = true;
        }
    }

    protected virtual async ValueTask DisposeAsyncCore()
    {
        if (!_disposed)
        {
            if (_currentTransaction != null)
            {
                await _currentTransaction.DisposeAsync().ConfigureAwait(false);
            }
            if (_context != null)
            {
                await _context.DisposeAsync().ConfigureAwait(false);
            }
        }
    }

    public async Task ExecuteTransactionAsync(Func<Task> func, CancellationToken cancellationToken)
    {
        var strategy = _context.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await func();
                // Your operations here
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        });
    }

    public async Task<TResult> ExecuteTransactionAsync<TResult>(Func<Task> func, CancellationToken cancellationToken)
    {
        var strategy = _context.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await func();
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        });
        return default;
    }
}