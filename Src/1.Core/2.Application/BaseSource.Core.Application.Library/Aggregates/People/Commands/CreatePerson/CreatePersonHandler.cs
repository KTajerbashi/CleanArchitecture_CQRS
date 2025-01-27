using BaseSource.Core.Application.Library.Aggregates.People.Repositories;
using BaseSource.Core.Application.Library.BaseApplication.ApplicationServices.Commands;
using BaseSource.Core.Application.Library.BaseApplication.RequestResponse.Commands;
using BaseSource.Core.Application.Library.BaseApplication.Utilities;
using BaseSource.Core.Domain.Library.Aggregates.People.Entities;

namespace BaseSource.Core.Application.Library.Aggregates.People.Commands.CreatePerson;

public class CreatePersonHandler : CommandHandler<CreatePerson, Guid>
{
    private readonly IPersonCommandRepository personCommandRepository;

    public CreatePersonHandler(UtilitiesServices utilitiesServices, IPersonCommandRepository personCommandRepository) : base(utilitiesServices)
    {
        this.personCommandRepository = personCommandRepository;
    }

    public override Task<CommandResult<Guid>> Handle(CreatePerson request, CancellationToken cancellationToken)
    {
        var entity = new Person(
            request.FirstName,
            request.LastName,
            $"{request.FirstName}_{request.LastName}@mail.com",
            $"{request.FirstName}_{request.LastName}",
            "09021301500");
        entity.ChangeFirstName(entity.FirstName.Value);
        personCommandRepository.Insert(entity);
        personCommandRepository.Commit();
        return OkAsync(entity.BusinessId.Value);
    }
}
