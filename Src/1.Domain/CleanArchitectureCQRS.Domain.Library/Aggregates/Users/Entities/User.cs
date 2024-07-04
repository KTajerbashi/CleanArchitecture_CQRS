using CleanArchitectureCQRS.Domain.Library.Aggregates.People.ValueObjects;
using CleanArchitectureCQRS.Domain.Library.Aggregates.Users.DomainEvents;
using CleanArchitectureCQRS.Domain.Library.BaseDomain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitectureCQRS.Domain.Library.Aggregates.Users.Entities;

[Table("Users", Schema = "Security"), Description("Users System")]
public class User : AggregateRoot<int>
{
    public FirstName FirstName { get; set; }
    public LastName LastName { get; set; }
    public UserName UserName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    private User()
    {

    }
    public User(string firstName, string lastName, string email, string username, string phone)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
        UserName = username;
        AddEvent(new UserCreated(
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
