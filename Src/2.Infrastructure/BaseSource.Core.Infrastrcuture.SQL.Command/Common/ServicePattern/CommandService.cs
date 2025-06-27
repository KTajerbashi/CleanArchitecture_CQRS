
namespace BaseSource.Core.Infrastrcuture.SQL.Command.Common.ServicePattern;

public abstract class CommandService<TEntity, TId> : ICommandService<TEntity, TId>
    where TEntity : AggregateRoot<TId>
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    protected readonly ICommandRepository<TEntity, TId> Repository;
    protected CommandService(ICommandRepository<TEntity, TId> repository)
    {
        Repository = repository;
    }
}



