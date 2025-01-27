using BaseSource.EndPoint.WebApi.BaseWebApi.Controllers;
using BaseSource.EndPoint.WebApi.HostExtensions.Providers.Identity.Repositories;
using BaseSource.EndPoint.WebApi.Models.Identity.Account;
using BaseSource.EndPoint.WebApi.Models.Identity.Authenticate;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BaseSource.EndPoint.WebApi.Controllers.Identity;

public class AuthenticateController : BaseController
{
    private readonly UserManager<IdentityUser> UserManager;
    private readonly RoleManager<IdentityRole> RoleManager;
    private readonly SignInManager<IdentityUser> SignInManager;
    private readonly IConfiguration Configuration;
    private readonly IJWTServiceToken jWTServiceToken;
    public AuthenticateController(IMediator mediator, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration, IJWTServiceToken jWTServiceToken) : base(mediator)
    {
        UserManager = userManager;
        RoleManager = roleManager;
        SignInManager = signInManager;
        Configuration = configuration;
        this.jWTServiceToken = jWTServiceToken;
    }

    [HttpPost("Login")]
    public Task<IActionResult> Login(LoginModel model)
    {
        IActionResult response = Unauthorized();
        UserModel user = null;

        var userEntity = UserManager.FindByNameAsync(model.Username).Result;
        if (userEntity is null)
            response = NotFound();
        var result = SignInManager.PasswordSignInAsync(userEntity,model.Password,model.IsRemember,true).Result;
        if (!result.Succeeded)
            response = BadRequest();

        var loginResult = jWTServiceToken.CreateToken(userEntity);
        response = Ok(loginResult);
        return ReturnResponse(response);
    }

    [Authorize]
    [HttpGet("Logout")]
    public async Task<IActionResult> Logout()
    {
        return await ReturnResponse(SignInManager.SignOutAsync());
    }

    [Authorize]
    [HttpGet("Authorized")]
    public async Task<IActionResult> Authorized()
    {
        return await ReturnResponse("Authorized");
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("AuthorizedAdmin")]
    public async Task<IActionResult> AuthorizedAdmin()
    {
        return await ReturnResponse("Authorized");
    }


    [Authorize(Roles = "User")]
    [HttpGet("AuthorizedUser")]
    public async Task<IActionResult> AuthorizedUser()
    {
        return await ReturnResponse("AuthorizedUser");
    }

    [HttpGet("NonAuthorized")]
    public async Task<IActionResult> NonAuthorized()
    {
        return await ReturnResponse("NonAuthorized");
    }


}

