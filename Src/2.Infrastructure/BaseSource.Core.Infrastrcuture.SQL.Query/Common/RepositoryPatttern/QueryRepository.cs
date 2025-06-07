using BaseSource.Core.Application.Common.RepositoryPatttern;
using BaseSource.Core.Domain.Common.Aggregate;
using BaseSource.Core.Domain.ValueObjects;
using BaseSource.Core.Infrastrcuture.SQL.Query.Common.DataContext;

namespace BaseSource.Core.Infrastrcuture.SQL.Query.Common.RepositoryPatttern;

public abstract class QueryRepository<TEntity, TId, TContext> : IQueryRepository<TEntity, TId>
    where TEntity : AggregateRoot<TId>
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
    where TContext : BaseQueryDataContext
{
    protected readonly TContext Context;
    protected readonly DbSet<TEntity> Entity;
    protected QueryRepository(TContext context)
    {
        Context = context;
        Entity = Context.Set<TEntity>();
    }

    public virtual async Task<TEntity> GetAsync(TId id)
    {
        return await Entity.SingleAsync(item => item.Id.Equals(id));
    }

    public virtual async Task<TEntity> GetAsync(EntityId entityId)
    {
        return await Entity.SingleAsync(item => item.EntityId.Equals(entityId));
    }

    public virtual async Task<TEntity> GetAsync(TEntity entity)
    {
        await Task.CompletedTask;
        return Entity.Entry(entity).Entity;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAsync()
    {
        return await Entity.Where(item => item.IsActive && !item.IsDeleted).ToListAsync();
    }

    public async Task<TEntity> GetGraphAsync(EntityId entityId)
    {
        var graphPath = Context.GetIncludePaths(typeof(TEntity));
        IQueryable<TEntity> query = Context.Set<TEntity>().AsQueryable();
        foreach (var item in graphPath)
        {
            query = query.Include(item);
        }
        return await query.FirstOrDefaultAsync(item => item.EntityId == entityId);
    }

    public virtual IQueryable<TEntity> Queryable()
    {
        return Entity.Where(item => item.IsActive && !item.IsDeleted).AsQueryable();
    }
}
