namespace BaseSource.Core.Application.UseCases.Identity.User.Handlers.Queries.GetById;
public class UserGetByIdQuery : Query<UserGetByIdQueryModel>
{
    public long Id { get; set; }

    public UserGetByIdQuery(long id)
    {
        Id = id;
    }
}
