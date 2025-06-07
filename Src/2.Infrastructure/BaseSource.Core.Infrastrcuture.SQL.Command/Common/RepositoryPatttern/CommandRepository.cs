using BaseSource.Core.Infrastrcuture.SQL.Command.Common.UnitOfWorkPatter;

namespace BaseSource.Core.Infrastrcuture.SQL.Command.Common.RepositoryPatttern;

public abstract class CommandRepository<TEntity, TId, TContext> : UnitOfWork<TContext>, ICommandRepository<TEntity, TId>
    where TEntity : AggregateRoot<TId>
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

    //protected CommandRepository(TContext context) : base(context)
    //{
    //    Context = context;
    //    Entity = Context.Set<TEntity>();
    //}

    public async Task DeleteAsync(TId id, CancellationToken cancellationToken = default)
    {
        TEntity entity = await Context.Set<TEntity>().SingleAsync(item => item.Id.Equals(id));
        entity.Delete();
    }

    public async Task DeleteAsync(EntityId entityId, CancellationToken cancellationToken = default)
    {
        TEntity entity = await Context.Set<TEntity>().SingleAsync(item => item.EntityId.Equals(entityId));
        entity.Delete();
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;
        entity.Delete();
    }

    public async Task<TEntity> GetAsync(TId id, CancellationToken cancellationToken = default)
        => await Context.Set<TEntity>().SingleAsync(item => item.Id.Equals(id));

    public async Task<TEntity> GetAsync(EntityId entityId, CancellationToken cancellationToken = default)
        => await Context.Set<TEntity>().SingleAsync(item => item.EntityId.Equals(entityId));

    public async Task<TEntity> GetAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        //return Entity.Entry(entity).Entity;
        return await Context.Set<TEntity>().SingleAsync(item => item.EntityId.Equals(entity.EntityId)) ?? throw new InvalidOperationException();
    }
    public async Task<TEntity> GetGraphAsync(EntityId entityId, CancellationToken cancellationToken = default)
    {
        var graphPath = Context.GetIncludePaths(typeof(TEntity));
        IQueryable<TEntity> query = Context.Set<TEntity>().AsQueryable();
        foreach (var item in graphPath)
        {
            query = query.Include(item);
        }
        return await query.FirstOrDefaultAsync(item => item.EntityId.Equals(entityId));
    }
    public async Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken = default)
        => await Context.Set<TEntity>().Where(item => item.IsActive && !item.IsDeleted).ToListAsync();

    public async Task<TId> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
       => (await Context.Set<TEntity>().AddAsync(entity)).Entity.Id;

    public IQueryable<TEntity> Queryable()
    {
        return Context.Set<TEntity>().Where(item => item.IsActive && !item.IsDeleted).AsQueryable();
    }
}