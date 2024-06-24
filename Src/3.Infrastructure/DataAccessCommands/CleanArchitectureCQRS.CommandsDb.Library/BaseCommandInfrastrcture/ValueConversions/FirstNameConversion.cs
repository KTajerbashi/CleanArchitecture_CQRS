using CleanArchitectureCQRS.Domain.Library.Aggregates.People.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CleanArchitectureCQRS.CommandsDb.Library.BaseCommandInfrastrcture.ValueConversions
{
    public class FirstNameConversion : ValueConverter<FirstName, string>
    {
        public FirstNameConversion() : base(c => c.Value, c => FirstName.FromString(c))
        {

        }
    }
}
