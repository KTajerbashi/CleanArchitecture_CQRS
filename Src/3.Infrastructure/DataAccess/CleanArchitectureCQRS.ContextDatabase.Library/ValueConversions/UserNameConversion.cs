using CleanArchitectureCQRS.Domain.Library.Aggregates.People.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CleanArchitectureCQRS.ContextDatabase.Library.ValueConversions
{
    public class UserNameConversion : ValueConverter<UserName, string>
    {
        public UserNameConversion() : base(c => c.Value, c => UserName.FromString(c))
        {

        }
    }
}
