using BaseSource.Core.Application.Models;
using BaseSource.Core.Infrastrcuture.SQL.Identity;
using BaseSource.WebAPI.EndPoint.Common.Models.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BaseSource.WebAPI.EndPoint.Controllers.Identity;

public class AuthenticationController : BaseController
{
    private readonly UserManager<UserIdentity> _userManager;
    private readonly SignInManager<UserIdentity> _signInManager;
    private readonly IConfiguration _configuration;

    public AuthenticationController(
        UserManager<UserIdentity> userManager,
        SignInManager<UserIdentity> signInManager,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            return ReturnResponse(false, "Invalid login attempt");
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        if (!result.Succeeded)
        {
            return ReturnResponse(false, "Invalid login attempt");
        }

        var token = await GenerateJwtToken(user);
        var refreshToken = GenerateRefreshToken();

        //user.RefreshToken = refreshToken;
        //user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(_configuration.GetSection("Identity:Jwt:RefreshTokenExpireDays").Get<int>());
        //await _userManager.UpdateAsync(user);

        return ReturnResponse(new AuthResponse
        {
            Token = token,
            RefreshToken = refreshToken,
            ExpiresIn = DateTime.UtcNow.AddMinutes(
                _configuration.GetSection("Identity:Jwt:ExpireMinutes").Get<int>())
        });
    }

    [HttpPost("SignUp")]
    public async Task<IActionResult> SignUp([FromBody] SignUpRequest request)
    {
        var user = new UserIdentity
        {
            UserName = request.Email,
            Email = request.Email,
            //FirstName = request.FirstName,
            //LastName = request.LastName
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            return ReturnResponse(false, errors: result.Errors.Select(item => item.Description));
        }

        // Add to default role if needed
        await _userManager.AddToRoleAsync(user, "User");

        return ReturnResponse(true, "User created successfully");
    }

    [HttpGet("IsAuthenticated")]
    public IActionResult IsAuthenticated()
    {
        return ReturnResponse(User.Identity?.IsAuthenticated ?? false);
    }

    [Authorize]
    [HttpGet("IsAuthorized")]
    public IActionResult IsAuthorized()
    {
        return ReturnResponse(true);
    }

    [HttpGet("UserClaims")]
    public IActionResult UserClaims()
    {
        var claims = User.Claims.Select(item => new KeyValueDTO(item.Type, item.Value)).ToList();
        return ReturnResponse(claims);
    }

    [Authorize(Policy = "RequireAdminRole")]
    [HttpGet("admin-only")]
    public IActionResult AdminEndpoint()
    {
        return ReturnResponse("Admin access granted");
    }

    [Authorize]
    [HttpGet("UserInfo")]
    public async Task<IActionResult> UserInfo()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return ReturnResponse(false, "User not found");
        }

        var roles = await _userManager.GetRolesAsync(user);

        return ReturnResponse(new UserInfoResponse
        {
            Id = user.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Roles = roles.ToList()
        });
    }

    [Authorize]
    [HttpPut("RemoveAccount")]
    public async Task<IActionResult> RemoveAccount()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return ReturnResponse(false, "User not found");
        }

        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded)
        {
            return ReturnResponse(false, errors: result.Errors.Select(e => e.Description));
        }

        await HttpContext.SignOutAsync();
        return ReturnResponse(true, "Account deleted successfully");
    }

    [HttpGet("ForgotPassword/{email}")]
    public async Task<IActionResult> ForgotPassword(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            // Don't reveal that the user doesn't exist
            return ReturnResponse(true, "If your email exists, you'll receive a password reset link");
        }

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        // In a real app, you would send the token via email
        return ReturnResponse(new { Token = token });
    }

    [HttpPut("ResetPassword")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            return ReturnResponse(false, "Invalid request");
        }

        var result = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);
        if (!result.Succeeded)
        {
            return ReturnResponse(false, errors: result.Errors.Select(e => e.Description).ToList());
        }

        return ReturnResponse(true, "Password reset successfully");
    }

    [HttpPost("RefreshToken")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
    {
        var principal = GetPrincipalFromExpiredToken(request.Token);
        if (principal?.Identity?.Name == null)
        {
            return ReturnResponse(false, "Invalid token");
        }

        var user = await _userManager.FindByNameAsync(principal.Identity.Name);
        //if (user == null || user.RefreshToken != request.RefreshToken ||
        //    user.RefreshTokenExpiryTime <= DateTime.UtcNow)
        //{
        //    return ReturnResponse(false, "Invalid refresh token");
        //}

        var newToken = await GenerateJwtToken(user);
        var newRefreshToken = GenerateRefreshToken();

        //user.RefreshToken = newRefreshToken;
        //user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(
        //    _configuration.GetSection("Identity:Jwt:RefreshTokenExpireDays").Get<int>());
        //await _userManager.UpdateAsync(user);

        return ReturnResponse(new AuthResponse
        {
            Token = newToken,
            RefreshToken = newRefreshToken,
            ExpiresIn = DateTime.UtcNow.AddMinutes(
                _configuration.GetSection("Identity:Jwt:ExpireMinutes").Get<int>())
        });
    }

    #region Private Methods

    private async Task<string> GenerateJwtToken(UserIdentity user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.GivenName, user.FirstName),
            new Claim(ClaimTypes.Surname, user.LastName)
        };

        // Add roles
        var roles = await _userManager.GetRolesAsync(user);
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            _configuration["Identity:Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.UtcNow.AddMinutes(
            _configuration.GetSection("Identity:Jwt:ExpireMinutes").Get<int>());

        var token = new JwtSecurityToken(
            issuer: _configuration["Identity:Jwt:Issuer"],
            audience: _configuration["Identity:Jwt:Audience"],
            claims: claims,
            expires: expires,
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private static string GenerateRefreshToken()
    {
        return Guid.NewGuid().ToString();
    }

    private ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Identity:Jwt:Key"]!)),
            ValidateLifetime = false
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out _);
            return principal;
        }
        catch
        {
            return null;
        }
    }

    #endregion
}



