using BaseSource.Core.Application.UseCases.Identity.User.Handlers.Commands.Create;
using BaseSource.Core.Application.UseCases.Identity.User.Handlers.Queries.GetById;

namespace BaseSource.WebAPI.EndPoint.Controllers.Identity;

public class UserController : AuthorizeController
{
    [HttpPost]
    public async Task<IActionResult> Create(UserCreateCommand command)
    {
        return await CreateAsync<UserCreateCommand, UserCreateResponse>(command);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Create(long id)
    {
        return await GetAsync<UserGetByIdQuery, UserGetByIdQueryModel>(new UserGetByIdQuery(id));
    }
}