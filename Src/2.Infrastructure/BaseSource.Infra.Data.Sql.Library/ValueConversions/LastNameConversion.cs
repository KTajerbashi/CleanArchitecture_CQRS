using BaseSource.Core.Domain.Library.Entities.People.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BaseSource.Infra.Data.Sql.Library.ValueConversions
{
    public class LastNameConversion : ValueConverter<LastName, string>
    {
        public LastNameConversion() : base(c => c.Value, c => LastName.FromString(c))
        {

        }
    }
}
