using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.EndPoints.BaseWebApi.Controllers;
using WebApi.EndPoints.HostExtensions.Providers.Identity.Repositories;
using WebApi.EndPoints.Models.Identity.Authorization;

namespace WebApi.EndPoints.Controllers.Identity;
public class AuthorizationController : BaseController
{
    private readonly UserManager<IdentityUser> UserManager;
    private readonly RoleManager<IdentityRole> RoleManager;
    private readonly SignInManager<IdentityUser> SignInManager;
    private readonly IJWTServiceToken jWTServiceToken;
    public AuthorizationController(IMediator mediator, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager, IJWTServiceToken jWTServiceToken) : base(mediator)
    {
        UserManager = userManager;
        RoleManager = roleManager;
        SignInManager = signInManager;
        this.jWTServiceToken = jWTServiceToken;
    }


    [HttpPost("Register")]
    public Task<IActionResult> Register(RegisterModel model)
    {
        var User = new IdentityUser
        {
            Email = model.Email,
            UserName=model.UserName,
            ConcurrencyStamp=Guid.NewGuid().ToString("D"),
            PhoneNumber=model.PhoneNumber,
        };

        var isCreated =UserManager.CreateAsync(User, model.Password).Result;
        if (!isCreated.Succeeded)
            return ReturnResponse(BadRequest());

        var isAdded = UserManager.AddToRoleAsync(User, "User").Result;
        if (!isAdded.Succeeded)
            return ReturnResponse(BadRequest());

        return ReturnResponse(jWTServiceToken.CreateToken(User));
    }

    [HttpPost("ForgotPassword")]
    public Task<IActionResult> ForgotPassword()
    {
        return ReturnResponse("");
    }

    [Authorize(Roles = "Admin,User")]
    [HttpDelete("DeleteAccount")]
    public Task<IActionResult> DeleteAccount()
    {
        return ReturnResponse("");
    }

    [HttpGet("DisActiveAccount")]
    public Task<IActionResult> DisActiveAccount()
    {
        return ReturnResponse("");
    }

    [Authorize(Roles = "User")]
    [HttpPut("ChangeStatusUser")]
    public Task<IActionResult> ChangeStatusUser()
    {
        return ReturnResponse("");
    }


    [Authorize(Roles = "Admin")]
    [HttpPut("UpdateClaims")]
    public Task<IActionResult> UpdateClaims()
    {
        return ReturnResponse("");
    }
}

