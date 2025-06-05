using BaseSource.Core.Application.Common.RepositoryPatttern;

namespace BaseSource.Core.Application.UseCases.Identity.User.Repositories;

public interface IUserQueryRepository : IQueryRepository<UserEntity, long>
{
}
