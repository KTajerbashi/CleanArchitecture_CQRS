namespace BaseSource.WebAPI.EndPoint.Controllers.Identity;

public class AuthenticationController : BaseController
{
    [HttpPost("Login")]
    public async Task<IActionResult> Login()
    {
        await Task.Delay(1000);
        return ReturnResponse();
    }
    [HttpPost("SignUp")]
    public async Task<IActionResult> SignUp()
    {
        await Task.Delay(1000);
        return ReturnResponse();
    }
    [HttpPut("RemoveAccount")]
    public async Task<IActionResult> RemoveAccount()
    {
        await Task.Delay(1000);
        return ReturnResponse();
    }
    [HttpGet("ForgotPassword")]
    public async Task<IActionResult> ForgotPassword()
    {
        await Task.Delay(1000);
        return ReturnResponse();
    }
}
