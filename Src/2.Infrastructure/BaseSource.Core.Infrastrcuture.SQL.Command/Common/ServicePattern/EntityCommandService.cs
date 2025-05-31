
namespace BaseSource.Core.Infrastrcuture.SQL.Command.Common.ServicePattern;

public abstract class EntityCommandService<TEntity, TId> : IEntityCommandService<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    protected readonly ICommandRepository<TEntity, TId> Repository;
    protected EntityCommandService(ICommandRepository<TEntity, TId> repository)
    {
        Repository = repository;
    }
}



