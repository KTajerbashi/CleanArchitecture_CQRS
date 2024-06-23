using CleanArchitectureCQRS.Application.Library.BaseApplication.ApplicationServices.Commands;
using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Commands;
using CleanArchitectureCQRS.Application.Library.BaseApplication.Utilities;

namespace CleanArchitectureCQRS.Application.Library.Aggregates.People.Commands.ChangePassword;

public class ChangePasswordHandler : CommandHandler<ChangePassword, int>
{
    public ChangePasswordHandler(UtilitiesServices utilitiesServices) : base(utilitiesServices)
    {
    }

    public override Task<CommandResult<int>> Handle(ChangePassword request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
