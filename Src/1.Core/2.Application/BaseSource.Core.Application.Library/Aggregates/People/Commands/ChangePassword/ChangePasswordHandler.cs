using BaseSource.Core.Application.Library.BaseApplication.ApplicationServices.Commands;
using BaseSource.Core.Application.Library.BaseApplication.RequestResponse.Commands;
using BaseSource.Core.Application.Library.BaseApplication.RequestResponse.Common;
using BaseSource.Core.Application.Library.BaseApplication.Utilities;

namespace BaseSource.Core.Application.Library.Aggregates.People.Commands.ChangePassword;

public class ChangePasswordHandler : CommandHandler<ChangePassword, int>
{
    public ChangePasswordHandler(UtilitiesServices utilitiesServices) : base(utilitiesServices)
    {
    }

    public override Task<CommandResult<int>> Handle(ChangePassword request, CancellationToken cancellationToken)
    {
        return ResultAsync(10, ApplicationServiceStatus.ValidationError);
    }
}
