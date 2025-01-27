using BaseSource.Core.Application.Library.BaseApplication.RequestResponse.Commands;

namespace BaseSource.Core.Application.Library.Aggregates.People.Commands.UpdatePerson;

public class UpdatePerson : ICommand<int>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
