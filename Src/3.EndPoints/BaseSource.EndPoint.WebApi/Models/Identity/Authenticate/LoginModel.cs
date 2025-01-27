namespace BaseSource.EndPoint.WebApi.Models.Identity.Authenticate;
public class LoginModel
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string ReturnUrl { get; set; }
    public bool IsRemember { get; set; }
}
