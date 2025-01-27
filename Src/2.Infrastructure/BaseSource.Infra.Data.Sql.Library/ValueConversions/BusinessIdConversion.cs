using BaseSource.Core.Domain.Library.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BaseSource.Infra.Data.Sql.Library.ValueConversions
{
    public class BusinessIdConversion : ValueConverter<BusinessId, Guid>
    {
        public BusinessIdConversion() : base(c => c.Value, c => BusinessId.FromGuid(c))
        {

        }
    }
}
