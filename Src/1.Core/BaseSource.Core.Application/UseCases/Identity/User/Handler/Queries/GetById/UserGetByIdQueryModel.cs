namespace BaseSource.Core.Application.UseCases.Identity.User.Handler.Queries.GetById;

public class UserGetByIdQueryModel : QueryModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
}
