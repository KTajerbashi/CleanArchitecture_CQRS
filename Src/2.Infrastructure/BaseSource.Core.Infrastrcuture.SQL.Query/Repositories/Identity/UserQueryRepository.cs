
using BaseSource.Core.Infrastrcuture.SQL.Identity;
using BaseSource.Core.Infrastrcuture.SQL.Query.Common.Exceptions;
using Microsoft.AspNetCore.Identity;
using static BaseSource.Core.Domain.Aggregates.Identity.UserAggregate.Parameters.UserParameters;

namespace BaseSource.Core.Infrastrcuture.SQL.Query.Repositories.Identity;

public class UserQueryRepository : QueryRepository<UserEntity, long, QueryDataContext>, IUserQueryRepository
{
    private readonly UserManager<UserIdentity> _userManager;
    public UserQueryRepository(QueryDataContext context, UserManager<UserIdentity> userManager) : base(context)
    {
        _userManager = userManager;
    }

    public override async Task<UserEntity> GetAsync(long id)
    {
        try
        {
            var entity = await _userManager.FindByIdAsync($"{id}");
            if (entity == null)
                throw new InfraQueryException("Not Found");

            var parameter = new UserModelParameter(
                entity.Id,
                entity.EntityId.Value,
                entity.FirstName,
                entity.LastName,
                entity.NationalCode,
                entity.UserName,
                entity.NormalizedUserName,
                entity.Email,
                entity.NormalizedEmail,
                entity.EmailConfirmed,
                entity.PasswordHash,
                entity.SecurityStamp,
                entity.ConcurrencyStamp,
                entity.PhoneNumber,
                entity.PhoneNumberConfirmed,
                entity.TwoFactorEnabled,
                entity.LockoutEnd,
                entity.LockoutEnabled,
                entity.AccessFailedCount
                );
            return UserEntity.MapModel(parameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
