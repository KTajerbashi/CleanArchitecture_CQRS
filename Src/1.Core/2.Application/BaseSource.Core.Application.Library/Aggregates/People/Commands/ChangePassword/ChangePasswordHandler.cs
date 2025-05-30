namespace BaseSource.Core.Application.Library.Aggregates.People.Commands.ChangePassword;

public class ChangePasswordHandler : CommandHandler<ChangePassword, int>
{
    public ChangePasswordHandler(ProviderUtilities providerUtilities) : base(providerUtilities)
    {
    }

    public override Task<CommandResult<int>> Handle(ChangePassword request, CancellationToken cancellationToken)
    {
        return ResultAsync(10, ApplicationServiceStatus.ValidationError);
    }
}
