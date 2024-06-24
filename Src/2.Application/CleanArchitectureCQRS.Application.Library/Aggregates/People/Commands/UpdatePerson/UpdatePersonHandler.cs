using CleanArchitectureCQRS.Application.Library.Aggregates.People.Repositories;
using CleanArchitectureCQRS.Application.Library.BaseApplication.ApplicationServices.Commands;
using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Commands;
using CleanArchitectureCQRS.Application.Library.BaseApplication.Utilities;

namespace CleanArchitectureCQRS.Application.Library.Aggregates.People.Commands.UpdatePerson;

public class UpdatePersonHandler : CommandHandler<UpdatePerson, int>
{
    private readonly IPersonCommandRepository personCommandRepository;
    public UpdatePersonHandler(UtilitiesServices utilitiesServices, IPersonCommandRepository personCommandRepository) : base(utilitiesServices)
    {
        this.personCommandRepository = personCommandRepository;
    }

    public override Task<CommandResult<int>> Handle(UpdatePerson request, CancellationToken cancellationToken)
    {
        return OkAsync(0);
    }
}
