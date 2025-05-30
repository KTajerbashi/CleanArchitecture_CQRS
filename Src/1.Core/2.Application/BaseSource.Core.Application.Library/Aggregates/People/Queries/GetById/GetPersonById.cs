using BaseSource.Core.Application.Library.Common.RequestResponse.EndPoints;
using BaseSource.Core.Application.Library.Common.RequestResponse.Queries;

namespace BaseSource.Core.Application.Library.Aggregates.People.Queries.GetById;

public class GetPersonById : IQuery<PersonQuery>, IWebRequest
{
    public int PersonId { get; set; }
    public string Path => "/api/Person/GetPersonById";
}
