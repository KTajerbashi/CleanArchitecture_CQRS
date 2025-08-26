namespace BaseSource.Core.Application.Common.RepositoryPatttern;

public interface IQueryRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    Task<TEntity> GetAsync(TId id);
    Task<TEntity> GetAsync(EntityId entityId);
    Task<TEntity> GetAsync(TEntity entity);


    Task<TEntity> GetGraphAsync(EntityId entityId);


    Task<IEnumerable<TEntity>> GetAsync();
    IQueryable<TEntity> Queryable();
}
