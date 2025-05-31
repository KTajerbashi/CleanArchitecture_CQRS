using BaseSource.Core.Domain.Common.Aggregate;

namespace BaseSource.Core.Domain.Aggregates.Identity.RoleAggregate;

[Table("Roles", Schema = "Identity")]
public class RoleEntity : AggregateRoot
{
}

