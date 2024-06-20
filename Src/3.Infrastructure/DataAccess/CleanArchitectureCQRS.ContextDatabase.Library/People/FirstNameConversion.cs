using CleanArchitectureCQRS.Domain.Library.People.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;

namespace CleanArchitectureCQRS.ContextDatabase.Library.People
{
    public class FirstNameConversion : ValueConverter<FirstName, string>
    {
        public FirstNameConversion() : base(c => c.Value, c => FirstName.FromString(c))
        {

        }
    }
}
