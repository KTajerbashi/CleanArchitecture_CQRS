using Abstraction.Notification.Extensions;
using CleanArchitectureCQRS.Application.Library.Aggregates.People.Repositories;
using CleanArchitectureCQRS.CommandsDb.Library.BaseCommandInfrastrcture;
using CleanArchitectureCQRS.CommandsDb.Library.Database;
using CleanArchitectureCQRS.Domain.Library.Aggregates.People.Entities;

namespace CleanArchitectureCQRS.CommandsDb.Library.Aggregates.People;

public class PersonCommandRepository :
        BaseCommandRepository<Person, DbContextApplicationCommand, int>,
        IPersonCommandRepository
{
    private readonly IEmailRepository _emailRepository;
    public PersonCommandRepository(DbContextApplicationCommand dbContext, IEmailRepository emailRepository) : base(dbContext)
    {
        _emailRepository = emailRepository;
    }



    public async Task SendEmail()
    {
        var result = await _emailRepository.Send(new EmailOption
        {
            Username = "Tajerbahsi",
            TextMessage = "Give me an appointment",
            Password = "@Tajerbashi#",
            ContactNumber = "09020320844"
        });
    }

    public async Task RecieveEmail()
    {
        var result = await _emailRepository.Recieve(10,30);
    }
}
