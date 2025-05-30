using BaseSource.Core.Domain.Library.Common.Entities;
using BaseSource.Core.Domain.Library.Entities.People.DomainEvents;
using BaseSource.Core.Domain.Library.Entities.People.ValueObjects;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseSource.Core.Domain.Library.Entities.People.Entities;

[Table("People", Schema = "BUS"), Description("Users System")]
public class Person : AggregateRoot<int>
{
    public FirstName FirstName { get; set; }
    public LastName LastName { get; set; }
    public UserName UserName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    private Person()
    {

    }
    public Person(
        string firstName,
        string lastName,
        string email,
        string username,
        string phone)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
        UserName = username;
        AddEvent(new PersonCreated(
            BusinessId.Value,
            firstName,
            lastName,
            email,
            username,
            phone
            ));
    }
    public void ChangeFirstName(string firstName)
    {
        FirstName = firstName;
        AddEvent(new FirstNameChanged(Id, firstName));
    }
    public void ChangeUserName(string username)
    {
        UserName = username;
        AddEvent(new UserNameChanged(Id, username));
    }
}