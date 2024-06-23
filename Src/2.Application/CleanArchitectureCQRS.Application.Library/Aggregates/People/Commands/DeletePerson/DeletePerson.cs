using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Commands;

namespace CleanArchitectureCQRS.Application.Library.Aggregates.People.Commands.DeletePerson;

public record DeletePerson (int id): ICommand<int>;
