using BaseSource.Core.Application.Library.Aggregates.People.Repositories;
using BaseSource.Core.Domain.Library.Entities.People.Entities;
using BaseSource.Infra.Data.Sql.Command.Library.Database;
using BaseSource.Infra.Data.Sql.Command.Library.Patterns;

namespace BaseSource.Infra.Data.Sql.Command.Library.Aggregates.People;

public class PersonCommandRepository :
        BaseCommandRepository<Person, DatabaseContextCommand, int>,
        IPersonCommandRepository
{
    public PersonCommandRepository(DatabaseContextCommand dbContext) : base(dbContext)
    {
    }



    public async Task SendEmail()
    {
        
    }

    public async Task RecieveEmail()
    {
    }
}
