using CleanArchitectureCQRS.Application.Library.BaseApplication.ApplicationServices.Commands;
using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Commands;
using CleanArchitectureCQRS.Application.Library.BaseApplication.Utilities;

namespace CleanArchitectureCQRS.Application.Library.Aggregates.People.Commands.CreatePerson;

public class CreatePersonHandler : CommandHandler<CreatePerson, int>
{
    public CreatePersonHandler(UtilitiesServices utilitiesServices) : base(utilitiesServices)
    {
    }

    public override Task<CommandResult<int>> Handle(CreatePerson request, CancellationToken cancellationToken)
    {
        return OkAsync(0);
    }
}
