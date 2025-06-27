namespace BaseSource.Core.Application.Common.ServicePattern;
public interface ICommandService<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{

}
