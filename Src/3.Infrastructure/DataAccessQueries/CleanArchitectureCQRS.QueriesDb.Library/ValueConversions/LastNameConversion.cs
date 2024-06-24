using CleanArchitectureCQRS.Domain.Library.Aggregates.People.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CleanArchitectureCQRS.CommandsDb.Library.BaseCommandInfrastrcture.ValueConversions
{
    public class LastNameConversion : ValueConverter<LastName, string>
    {
        public LastNameConversion() : base(c => c.Value, c => LastName.FromString(c))
        {

        }
    }
}
