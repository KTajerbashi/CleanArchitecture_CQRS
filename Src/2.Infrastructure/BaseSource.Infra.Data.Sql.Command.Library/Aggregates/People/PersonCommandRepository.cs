using BaseSource.Core.Application.Library.Aggregates.People.Repositories;
using BaseSource.Core.Domain.Library.Aggregates.People.Entities;
using BaseSource.Infra.Data.Sql.Command.Library.BaseCommandInfrastrcture;
using BaseSource.Infra.Data.Sql.Command.Library.Database;

namespace BaseSource.Infra.Data.Sql.Command.Library.Aggregates.People;

public class PersonCommandRepository :
        BaseCommandRepository<Person, DbContextApplicationCommand, int>,
        IPersonCommandRepository
{
    public PersonCommandRepository(DbContextApplicationCommand dbContext) : base(dbContext)
    {
    }



    public async Task SendEmail()
    {
        
    }

    public async Task RecieveEmail()
    {
    }
}
