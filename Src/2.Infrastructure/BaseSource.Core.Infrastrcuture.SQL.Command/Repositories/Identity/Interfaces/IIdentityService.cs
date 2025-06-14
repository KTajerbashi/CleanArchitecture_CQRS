using BaseSource.Core.Application.Models;
using BaseSource.Core.Domain.Aggregates.Identity.UserAggregate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace BaseSource.Core.Infrastrcuture.SQL.Command.Repositories.Identity.Interfaces;

public interface IIdentityService
{
    public UserManager<UserIdentity> UserManager { get; }
    public RoleManager<RoleIdentity> RoleManager { get; }
    public SignInManager<UserIdentity> SignInManager { get; }

    public IAuthorizationService AuthorizationService { get; }
    public IHttpContextAccessor HttpContextAccessor { get; }

    //public IUserRepository UserRepository { get; }
    //public IUserLoginRepository UserLoginRepository { get; }
    //public IUserTokenRepository UserTokenRepository { get; }
    //public IUserRoleRepository UserRoleRepository { get; }
    //public IRoleRepository RoleRepository { get; }
    //public ITokenService TokenService { get; }

    Task<AuthResponse> LoginAsync(UserEntity entity);
    Task LogoutAsync();
}