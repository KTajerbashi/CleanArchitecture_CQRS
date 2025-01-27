using BaseSource.Core.Application.Library.Aggregates.People.Repositories;
using BaseSource.Core.Application.Library.BaseApplication.ApplicationServices.Commands;
using BaseSource.Core.Application.Library.BaseApplication.RequestResponse.Commands;
using BaseSource.Core.Application.Library.BaseApplication.RequestResponse.Common;
using BaseSource.Core.Application.Library.BaseApplication.Utilities;

namespace BaseSource.Core.Application.Library.Aggregates.People.Commands.ChangeName;

public class ChangeName : ICommand<int>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
}
public class ChangeNameHandler : CommandHandler<ChangeName, int>
{
    private readonly IPersonCommandRepository personCommandRepository;
    public ChangeNameHandler(UtilitiesServices utilitiesServices, IPersonCommandRepository personCommandRepository) : base(utilitiesServices)
    {
        this.personCommandRepository = personCommandRepository;
    }

    public override Task<CommandResult<int>> Handle(ChangeName request, CancellationToken cancellationToken)
    {
        var entity = personCommandRepository.Get(request.Id);
        entity.ChangeFirstName(request.FirstName);
        personCommandRepository.Commit();
        return ResultAsync(10, ApplicationServiceStatus.ValidationError);
    }
}