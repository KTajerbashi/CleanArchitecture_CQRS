using BaseSource.Core.Domain.ValueObjects;
using BaseSource.Core.Infrastrcuture.SQL.Command.Common.UnitOfWorkPatter;

namespace BaseSource.Core.Infrastrcuture.SQL.Command.Common.RepositoryPatttern;

public abstract class CommandRepository<TEntity, TId, TContext> : UnitOfWork<TContext>, ICommandRepository<TEntity, TId>
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

    protected CommandRepository(TContext context) : base(context)
    {
        Context = context;
        Entity = Context.Set<TEntity>();
    }

    public async Task DeleteAsync(TId id)
    {
        TEntity entity = await Context.Set<TEntity>().SingleAsync(item => item.Id.Equals(id));
        entity.Delete();
    }

    public async Task DeleteAsync(EntityId entityId)
    {
        TEntity entity = await Context.Set<TEntity>().SingleAsync(item => item.EntityId.Equals(entityId));
        entity.Delete();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        await Task.CompletedTask;
        entity.Delete();
    }

    public async Task<TEntity> GetAsync(TId id)
        => await Context.Set<TEntity>().SingleAsync(item => item.Id.Equals(id));

    public async Task<TEntity> GetAsync(EntityId entityId)
        => await Context.Set<TEntity>().SingleAsync(item => item.EntityId.Equals(entityId));

    public async Task<TEntity> GetAsync(TEntity entity)
    {
        //return Entity.Entry(entity).Entity;
        return await Context.Set<TEntity>().SingleAsync(item => item.EntityId.Equals(entity.EntityId)) ?? throw new InvalidOperationException();
    }

    public async Task<IEnumerable<TEntity>> GetAsync()
        => await Context.Set<TEntity>().Where(item => item.IsActive && !item.IsDeleted).ToListAsync();

    public async Task<TId> InsertAsync(TEntity entity)
       => (await Context.Set<TEntity>().AddAsync(entity)).Entity.Id;

    public IQueryable<TEntity> Queryable()
    {
        return Context.Set<TEntity>().Where(item => item.IsActive && !item.IsDeleted).AsQueryable();
    }
}