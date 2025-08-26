namespace BaseSource.Core.Application.Common.RepositoryPatttern;

public interface ICommandRepository<TEntity, TId> : IUnitOfWork
    where TEntity : Entity<TId>
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    Task<TId> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task<TEntity> GetAsync(TId id, CancellationToken cancellationToken = default);
    Task<TEntity> GetAsync(EntityId entityId, CancellationToken cancellationToken = default);
    Task<TEntity> GetGraphAsync(EntityId entityId, CancellationToken cancellationToken = default);
    Task<TEntity> GetAsync(TEntity entity, CancellationToken cancellationToken = default);


    Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken = default);
    IQueryable<TEntity> Queryable();

    Task DeleteAsync(TId id, CancellationToken cancellationToken = default);
    Task DeleteAsync(EntityId entityId, CancellationToken cancellationToken = default);
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

    string ContextId { get; }
}
