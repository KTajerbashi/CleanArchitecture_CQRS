using BaseSource.Core.Application.Library.BaseApplication.RequestResponse.Commands;

namespace BaseSource.Core.Application.Library.Aggregates.People.Commands.DeletePerson;

public record DeletePerson(int id) : ICommand<int>;
