using BaseSource.Core.Application.Library.Aggregates.People.Repositories;
using BaseSource.Core.Domain.Library.Entities.People.Entities;

namespace BaseSource.Core.Application.Library.Aggregates.People.Commands.CreatePerson;

public class CreatePersonHandler : CommandHandler<CreatePerson, Guid>
{
    private readonly IPersonCommandRepository _repository;

    public CreatePersonHandler(ProviderUtilities providerUtilities, IPersonCommandRepository repository) : base(providerUtilities)
    {
        _repository = repository;
    }

    public override async Task<CommandResult<Guid>> Handle(CreatePerson request, CancellationToken cancellationToken)
    {
        var entity = new Person(
            request.FirstName,
            request.LastName,
            $"{request.FirstName}_{request.LastName}@mail.com",
            $"{request.FirstName}_{request.LastName}",
            "09021301500");
        entity.ChangeFirstName(entity.FirstName.Value);
        await _repository.InsertAsync(entity);
        await _repository.CommitAsync();
        return await OkAsync(entity.BusinessId.Value);
    }
}
