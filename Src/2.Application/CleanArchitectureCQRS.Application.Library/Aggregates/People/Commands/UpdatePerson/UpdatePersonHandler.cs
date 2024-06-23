using CleanArchitectureCQRS.Application.Library.BaseApplication.ApplicationServices.Commands;
using CleanArchitectureCQRS.Application.Library.BaseApplication.ApplicationServices.Queries;
using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Commands;
using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Common;
using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Queries;
using CleanArchitectureCQRS.Application.Library.BaseApplication.Utilities;

namespace CleanArchitectureCQRS.Application.Library.Aggregates.People.Commands.UpdatePerson;

public class UpdatePersonHandler : CommandHandler<UpdatePerson, int>
{
    public UpdatePersonHandler(UtilitiesServices utilitiesServices) : base(utilitiesServices)
    {
    }

    public override Task<CommandResult<int>> Handle(UpdatePerson request, CancellationToken cancellationToken)
    {
        return OkAsync(0);
    }
}
