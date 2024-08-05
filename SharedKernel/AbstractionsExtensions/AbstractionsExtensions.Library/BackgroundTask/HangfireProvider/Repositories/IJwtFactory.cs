using System.Security.Claims;

namespace AbstractionsExtensions.Library.BackgroundTask.HangfireProvider.Repositories;

public interface IJwtFactory
{
    Task<string> GenerateEncodedToken(string userName, IList<Claim> claims);
    ClaimsPrincipal GetPrincipalFromToken(string token);
}
