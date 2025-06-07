using System.Transactions;

namespace BaseSource.Core.Application.Common.UnitOfWorkPatter;

//Key Points:
//Execution Strategy Integration:
//The ExecuteInTransactionAsync methods properly wrap operations in transactions managed by the execution strategy
//This is the recommended approach for most scenarios
//Explicit Transaction Management:
//The BeginTransactionAsync, CommitTransactionAsync, and RollbackTransactionAsync methods are provided for cases where you need explicit control
//These methods disable the execution strategy's retry behavior for the transaction
//Simplified Usage:
//The command handler becomes cleaner and more focused on business logic
//Transaction management is properly abstracted away
//Safety:
//Proper disposal of transactions
//Clear error handling paths
//Thread-safe operation

//When to Use Which Approach:
//Use ExecuteInTransactionAsync when:
//You want automatic retry for transient failures
//Your operation is a single logical unit of work
//You don't need to control the transaction outside the operation
//Use explicit transaction methods when:
//You need to span transactions across multiple operations
//You need to coordinate with external systems in the same transaction
//You require specific transaction isolation levels
//This implementation provides a robust solution that works with EF Core's execution strategy while giving you flexibility in how you manage transactions.
public interface IUnitOfWork : IDisposable, IAsyncDisposable, IScopedLifetime
{
    void BeginTransaction();
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);

    void CommitTransaction();
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);

    void RollbackTransaction();
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);

    void SaveChanges();
    Task SaveChangesAsync(CancellationToken cancellationToken = default);


    Task TransactionAsync(Func<Task> func, CancellationToken cancellationToken = default);
    Task<TResult> TransactionAsync<TResult>(Func<Task<TResult>> func, CancellationToken cancellationToken = default);
}