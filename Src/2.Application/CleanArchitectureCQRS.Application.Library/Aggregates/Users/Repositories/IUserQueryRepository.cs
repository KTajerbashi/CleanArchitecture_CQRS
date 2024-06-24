using CleanArchitectureCQRS.Application.Library.Aggregates.Users.Queires.GetUserById;
using CleanArchitectureCQRS.Application.Library.BaseApplication.Contracts.Data.Queries;

namespace CleanArchitectureCQRS.Application.Library.Aggregates.Users.Repositories;

public interface IUserQueryRepository : IQueryRepository
{
    UserModel GetUserById(int id);
    List<UserModel> GetAllUsers();
}
