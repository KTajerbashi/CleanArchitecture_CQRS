using BaseSource.Core.Application.UseCases.Identity.User.Repositories;

namespace BaseSource.Core.Infrastrcuture.SQL.Command.Repositories.Identity;

public class UserCommandRepository : CommandRepository<UserEntity, long, CommandDataContext>, IUserCommandRepository
{
    public UserCommandRepository(CommandDataContext context) : base(context)
    {
    }
}
