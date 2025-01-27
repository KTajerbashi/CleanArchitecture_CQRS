using BaseSource.EndPoint.WebApi.BaseWebApi.Controllers;
using BaseSource.EndPoint.WebApi.Models.Identity.Account;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BaseSource.EndPoint.WebApi.Controllers.Identity;

[Authorize]
public class AccountController : BaseController
{

    private readonly UserManager<IdentityUser> UserManager;
    private readonly RoleManager<IdentityRole> RoleManager;
    private readonly SignInManager<IdentityUser> SignInManager;
    public AccountController(IMediator mediator, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager) : base(mediator)
    {
        UserManager = userManager;
        RoleManager = roleManager;
        SignInManager = signInManager;
    }

    [HttpPost("CreateAccount")]
    public Task<IActionResult> CreateAccount()
    {
        return ReturnResponse("CreateAccount");
    }

    [HttpPut("UpdateAccount")]
    public Task<IActionResult> UpdateAccount()
    {
        return ReturnResponse("UpdateAccount");
    }

    [HttpDelete("DeleteAccount")]
    public Task<IActionResult> DeleteAccount()
    {
        return ReturnResponse("GetProfile");
    }

    [HttpGet("GetProfile")]
    public Task<IActionResult> GetProfile()
    {
        return ReturnResponse("GetProfile");
    }

    [HttpGet("GetUser")]
    public Task<IActionResult> GetUser()
    {
        return ReturnResponse("GetUser");
    }


    [HttpGet("GetAll")]
    public Task<IActionResult> GetAll()
    {
        return ReturnResponse("GetAll");
    }

    [HttpPost("AddRolesToUser")]
    public Task<IActionResult> AddRolesToUser(AddRolesToUser user)
    {
        var userEntity = UserManager.FindByNameAsync(user.UserName).Result;
        var result = UserManager.AddToRolesAsync(userEntity, user.Roles).Result;
        return ReturnResponse(result);
    }


    [HttpPost("CreateRole")]
    public Task<IActionResult> CreateRole(CreateRole role)
    {
        var roleEntity = new IdentityRole{Name=role.Name};
        var result = RoleManager.CreateAsync(roleEntity).Result;
        return ReturnResponse(result);
    }

    [HttpPost("CreateRoles")]
    public Task<IActionResult> CreateRoles(List<CreateRole> roles)
    {
        foreach (var item in roles)
        {
            var result = RoleManager.CreateAsync(new IdentityRole { Name = item.Name }).Result;
        }
        return ReturnResponse(true);
    }

}

