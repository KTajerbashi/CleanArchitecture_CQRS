using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.EndPoints;
using CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Queries;

namespace CleanArchitectureCQRS.Application.Library.Aggregates.People.Queries.GetById;

public class GetPersonByIdModel : IQuery<PersonQuery>, IWebRequest
{
    public int PersonId { get; set; }
    public string Path => "/api/Person/GetPersonById";
}
