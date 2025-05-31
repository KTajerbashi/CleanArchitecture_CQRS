namespace BaseSource.Core.Infrastrcuture.SQL.Command.Common.RepositoryPatttern;

public abstract class CommandRepository<TEntity, TId, TContext> : ICommandRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
    where TContext : BaseCommandDataContext
{

    protected TContext Context;
    protected DbSet<TEntity> Entity;

    protected CommandRepository(TContext context)
    {
        Context = context;
        Entity = Context.Set<TEntity>();
    }

    public Task DeleteAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(EntityId entityId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

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

    public Task<TId> InsertAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<TEntity>> QueryableAsync()
    {
        throw new NotImplementedException();
    }
}