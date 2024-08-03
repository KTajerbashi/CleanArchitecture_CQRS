namespace WebApi.EndPoints.Models.Identity.Authenticate;

public class AuthenticationRule
{
    public int Id { get; set; }
    public string RuleName { get; set; }
    public string Description { get; set; }
    public bool IsEnabled { get; set; }
}