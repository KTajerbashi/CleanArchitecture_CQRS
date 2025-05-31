using BaseSource.Core.Domain.Common.Aggregate;

namespace BaseSource.Core.Domain.Aggregates.Identity.UserAggregate;

[Table("Users", Schema = "Identity")]
public class UserEntitiy : AggregateRoot
{
}

