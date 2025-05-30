using BaseSource.Core.Application.Library.Aggregates.People.Repositories;

namespace BaseSource.Core.Application.Library.Aggregates.People.Commands.DeletePerson;

public class DeletePersonHandler : CommandHandler<DeletePerson, int>
{
    private readonly IPersonCommandRepository _repository;

    public DeletePersonHandler(ProviderUtilities providerUtilities, IPersonCommandRepository repository) : base(providerUtilities)
    {
        _repository = repository;
    }

    public override Task<CommandResult<int>> Handle(DeletePerson request, CancellationToken cancellationToken)
    {
        return OkAsync(0);
    }
}
