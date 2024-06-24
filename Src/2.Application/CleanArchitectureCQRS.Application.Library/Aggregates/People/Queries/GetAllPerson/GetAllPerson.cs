using CleanArchitectureCQRS.Application.Library.Aggregates.People.Queries.GetById;
using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Queries;

namespace CleanArchitectureCQRS.Application.Library.Aggregates.People.Queries.GetAllPerson;

public class GetAllPerson: IQuery<List<PersonQuery>>
{
    public GetAllPerson()
    {
        
    }
    public int ID { get; set; }
}
