using BaseSource.Core.Application.Library.Aggregates.People.Repositories;

namespace BaseSource.Core.Application.Library.Aggregates.People.Commands.UpdatePerson;

public class UpdatePersonHandler : CommandHandler<UpdatePerson, int>
{
    private readonly IPersonCommandRepository _repository;

    public UpdatePersonHandler(ProviderUtilities providerUtilities, IPersonCommandRepository repository) : base(providerUtilities)
    {
        _repository = repository;
    }

    public override Task<CommandResult<int>> Handle(UpdatePerson request, CancellationToken cancellationToken)
    {
        return OkAsync(0);
    }
}
