using CleanArchitectureCQRS.Application.Library.Aggregates.People.Repositories;
using CleanArchitectureCQRS.Application.Library.BaseApplication.ApplicationServices.Commands;
using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Commands;
using CleanArchitectureCQRS.Application.Library.BaseApplication.Utilities;

namespace CleanArchitectureCQRS.Application.Library.Aggregates.People.Commands.DeletePerson;

public class DeletePersonHandler : CommandHandler<DeletePerson, int>
{
    private readonly IPersonCommandRepository personCommandRepository;
    public DeletePersonHandler(UtilitiesServices utilitiesServices, IPersonCommandRepository personCommandRepository) : base(utilitiesServices)
    {
        this.personCommandRepository = personCommandRepository;
    }

    public override Task<CommandResult<int>> Handle(DeletePerson request, CancellationToken cancellationToken)
    {
        return OkAsync(0);
    }
}
