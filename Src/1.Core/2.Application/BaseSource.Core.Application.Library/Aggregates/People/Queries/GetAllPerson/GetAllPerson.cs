using BaseSource.Core.Application.Library.Aggregates.People.Queries.GetById;
using BaseSource.Core.Application.Library.BaseApplication.RequestResponse.Queries;

namespace BaseSource.Core.Application.Library.Aggregates.People.Queries.GetAllPerson;

public class GetAllPerson : IQuery<List<PersonQuery>>
{
    public GetAllPerson()
    {

    }
    public int ID { get; set; }
}
