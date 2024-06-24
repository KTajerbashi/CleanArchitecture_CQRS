using CleanArchitectureCQRS.Application.Library.Aggregates.People.Repositories;
using CleanArchitectureCQRS.Application.Library.BaseApplication.ApplicationServices.Commands;
using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Commands;
using CleanArchitectureCQRS.Application.Library.BaseApplication.Utilities;
using CleanArchitectureCQRS.Domain.Library.Aggregates.People.Entities;

namespace CleanArchitectureCQRS.Application.Library.Aggregates.People.Commands.CreatePerson;

public class CreatePersonHandler : CommandHandler<CreatePerson, Guid>
{
    private readonly IPersonCommandRepository personCommandRepository;
    public CreatePersonHandler(UtilitiesServices utilitiesServices, IPersonCommandRepository personCommandRepository) : base(utilitiesServices)
    {
        this.personCommandRepository = personCommandRepository;
    }

    public override Task<CommandResult<Guid>> Handle(CreatePerson request, CancellationToken cancellationToken)
    {
        var entity = new Person(request.FirstName, request.LastName);
        personCommandRepository.Insert(entity);
        return OkAsync(entity.BusinessId.Value);
    }
}
