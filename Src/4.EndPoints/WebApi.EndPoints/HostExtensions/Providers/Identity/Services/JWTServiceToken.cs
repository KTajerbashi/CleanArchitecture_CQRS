using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.EndPoints.HostExtensions.Providers.Identity.Repositories;
using WebApi.EndPoints.Models.Identity.Authenticate;

namespace WebApi.EndPoints.HostExtensions.Providers.Identity.Services;
public class JWTServiceToken: IJWTServiceToken
{
    private readonly UserManager<IdentityUser> UserManager;
    private readonly RoleManager<IdentityRole> RoleManager;
    private readonly SignInManager<IdentityUser> SignInManager;
    private readonly IConfiguration Configuration;
    public JWTServiceToken(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
    {
        UserManager = userManager;
        RoleManager = roleManager;
        SignInManager = signInManager;
        Configuration = configuration;
    }
    public TokenModel CreateToken(IdentityUser model)
    {
        var user = UserManager.FindByNameAsync(model.UserName).Result;

        var userRoles = UserManager.GetRolesAsync(user).Result;

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

        authClaims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

        var token = new JwtSecurityToken(
                issuer: Configuration["Jwt:Issuer"],
                audience: Configuration["Jwt:Issuer"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: creds);
        return (new TokenModel
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            ExpireDate = token.ValidTo
        });
    }
}
