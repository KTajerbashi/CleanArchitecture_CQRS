using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Commands;

namespace CleanArchitectureCQRS.Application.Library.Aggregates.People.Commands.CreatePerson;

public class CreatePerson : ICommand<int>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
