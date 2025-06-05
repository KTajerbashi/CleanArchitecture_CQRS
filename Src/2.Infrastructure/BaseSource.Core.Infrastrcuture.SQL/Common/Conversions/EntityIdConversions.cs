using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BaseSource.Core.Infrastrcuture.SQL.Common.Conversions;

public class EntityIdConversion : ValueConverter<EntityId, Guid>
{
    public EntityIdConversion() : base(c => c.Value, c => EntityId.FromGuid(c))
    {

    }
}