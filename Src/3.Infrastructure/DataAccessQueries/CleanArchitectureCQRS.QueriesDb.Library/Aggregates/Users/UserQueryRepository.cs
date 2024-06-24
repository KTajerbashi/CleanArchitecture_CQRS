using CleanArchitectureCQRS.Application.Library.Aggregates.Users.Queires.GetUserById;
using CleanArchitectureCQRS.Application.Library.Aggregates.Users.Repositories;
using CleanArchitectureCQRS.QueriesDb.Library.BaseQueriesInfrastrcture;
using CleanArchitectureCQRS.QueriesDb.Library.Database;

namespace CleanArchitectureCQRS.QueriesDb.Library.Aggregates.Users;

public class UserQueryRepository : BaseQueryRepository<DbContextApplicationQueries>, IUserQueryRepository
{
    public UserQueryRepository(DbContextApplicationQueries dbContext) : base(dbContext)
    {
    }

    public List<UserModel> GetAllUsers()
    {
        var result = _dbContext.Users.Select(item => new UserModel
        {
            FirstName = item.FirstName.Value,
            LastName = item.LastName.Value,
            Email = item.Email,
            Phone = item.Phone,
            Username = item.UserName.Value,
        }).ToList();
        return result;
    }

    public UserModel GetUserById(int id)
    {
        var result = _dbContext.Users.Select(item => new UserModel
        {
            FirstName = item.FirstName.Value,
            LastName = item.LastName.Value,
            Email = item.Email,
            Phone = item.Phone,
            Username = item.UserName.Value,
        }).FirstOrDefault(item => item.Id.Equals(id));
        return result;
    }
}
