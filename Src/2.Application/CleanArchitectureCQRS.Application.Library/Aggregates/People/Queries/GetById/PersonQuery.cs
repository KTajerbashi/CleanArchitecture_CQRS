namespace CleanArchitectureCQRS.Application.Library.Aggregates.People.Queries.GetById;

public class PersonQuery
{
    public int Id { get; set; }
    public Guid BusinessId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}