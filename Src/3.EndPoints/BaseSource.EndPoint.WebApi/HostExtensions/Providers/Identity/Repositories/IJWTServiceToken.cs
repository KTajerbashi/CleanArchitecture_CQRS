using BaseSource.EndPoint.WebApi.Models.Identity.Authenticate;
using Microsoft.AspNetCore.Identity;

namespace BaseSource.EndPoint.WebApi.HostExtensions.Providers.Identity.Repositories;

public interface IJWTServiceToken
{
    TokenModel CreateToken(IdentityUser model);
}
