using CleanArchitectureCQRS.Domain.Library.People.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CleanArchitectureCQRS.ContextDatabase.Library.People
{
    public class LastNameConversion : ValueConverter<LastName, string>
    {
        public LastNameConversion() : base(c => c.Value, c => LastName.FromString(c))
        {

        }
    }
}
