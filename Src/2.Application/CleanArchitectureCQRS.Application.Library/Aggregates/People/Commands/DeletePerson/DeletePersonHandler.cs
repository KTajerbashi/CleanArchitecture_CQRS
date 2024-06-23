using CleanArchitectureCQRS.Application.Library.BaseApplication.ApplicationServices.Commands;
using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Commands;
using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Common;
using CleanArchitectureCQRS.Application.Library.BaseApplication.Utilities;

namespace CleanArchitectureCQRS.Application.Library.Aggregates.People.Commands.DeletePerson;

public class DeletePersonHandler : CommandHandler<DeletePerson, int>
{
    public DeletePersonHandler(UtilitiesServices utilitiesServices) : base(utilitiesServices)
    {
    }

    public override Task<CommandResult<int>> Handle(DeletePerson request, CancellationToken cancellationToken)
    {
        return OkAsync(0);
    }
}
