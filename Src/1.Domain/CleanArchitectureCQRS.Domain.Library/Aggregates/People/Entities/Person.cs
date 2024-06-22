using CleanArchitectureCQRS.Domain.Library.Aggregates.People.DomainEvents;
using CleanArchitectureCQRS.Domain.Library.Aggregates.People.Resources;
using CleanArchitectureCQRS.Domain.Library.Aggregates.People.ValueObjects;
using CleanArchitectureCQRS.Domain.Library.BaseDomain.Entities;
using CleanArchitectureCQRS.Domain.Library.BaseDomain.Exceptions;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitectureCQRS.Domain.Library.Aggregates.People.Entities;

[Table("People", Schema = "Test"), Description("Users System")]
public class Person : AggregateRoot<int>
{
    #region Properties
    public FirstName FirstName { get; set; }
    public LastName LastName { get; set; }
    #endregion
    private Person()
    {

    }
    public Person(int id, string firstName, string lastName)
    {
        if (id < 1)
        {
            throw new InvalidEntityStateException(MessagePatterns.IdInvalidationMessage);
        }
        //Id = id;
        FirstName = firstName;
        LastName = lastName;
        AddEvent(new PersonCreated(id, BusinessId.Value, firstName, lastName));
    }
    public void ChangeFirstName(string firstName)
    {
        FirstName = firstName;
        AddEvent(new PersonNameChanged(Id, firstName));
    }
}