using BaseSource.Core.Application.Library.Common.RequestResponse.Commands;

namespace BaseSource.Core.Application.Library.Aggregates.People.Commands.DeletePerson;

public record DeletePerson(int id) : ICommand<int>;
