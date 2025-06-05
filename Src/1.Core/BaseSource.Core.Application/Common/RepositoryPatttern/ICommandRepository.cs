

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
    Task<TId> InsertAsync(TEntity entity);

    Task<TEntity> GetAsync(TId id);
    Task<TEntity> GetAsync(EntityId entityId);
    Task<TEntity> GetAsync(TEntity entity);


    Task<IEnumerable<TEntity>> GetAsync();
    IQueryable<TEntity> Queryable();

    Task DeleteAsync(TId id);
    Task DeleteAsync(EntityId entityId);
    Task DeleteAsync(TEntity entity);

}
