using BaseSource.Core.Domain.Library.Aggregates.People.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BaseSource.Infra.Data.Sql.Library.ValueConversions
{
    public class UserNameConversion : ValueConverter<UserName, string>
    {
        public UserNameConversion() : base(c => c.Value, c => UserName.FromString(c))
        {

        }
    }
}
