using Microsoft.AspNetCore.Identity;
using WebApi.EndPoints.Models.Identity.Authenticate;

namespace WebApi.EndPoints.HostExtensions.Providers.Identity.Repositories;

public interface IJWTServiceToken
{
    TokenModel CreateToken(IdentityUser model);
}
