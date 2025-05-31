using BaseSource.Core.Application.Common.RepositoryPatttern;
using BaseSource.Core.Domain.Common.Aggregate;
using BaseSource.Core.Domain.ValueObjects;
using BaseSource.Core.Infrastrcuture.SQL.Query.Common.DataContext;

namespace BaseSource.Core.Infrastrcuture.SQL.Query.Common.RepositoryPatttern;

public abstract class QueryRepository<TEntity, TId, TContext> : IQueryRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
    where TContext : BaseQueryDataContext
{
    public Task<TEntity> GetAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetAsync(EntityId entityId)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<TEntity>> QueryableAsync()
    {
        throw new NotImplementedException();
    }
}
