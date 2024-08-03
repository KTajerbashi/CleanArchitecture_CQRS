using CleanArchitectureCQRS.Domain.Library.Aggregates.People.DomainEvents;
using CleanArchitectureCQRS.Domain.Library.Aggregates.People.ValueObjects;
using CleanArchitectureCQRS.Domain.Library.BaseDomain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitectureCQRS.Domain.Library.Aggregates.People.Entities;

[Table("People", Schema = "BUS"), Description("Users System")]
public class Person : AggregateRoot<int>
{
    #region Properties
    public FirstName FirstName { get; set; }
    public LastName LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    #endregion
    private Person()
    {

    }
    public Person(string firstName, string lastName, string email, string phone)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
        AddEvent(new PersonCreated(BusinessId.Value, firstName, lastName));
    }
    public void ChangeFirstName(string firstName)
    {
        FirstName = firstName;
        //  AddEvent(new PersonNameChanged(Id, firstName));
    }
}