namespace BaseSource.EndPoint.WebApi.Models.Identity.Authenticate;

public class TokenModel
{
    public string Token { get; set; }
    public DateTime ExpireDate { get; set; }
}
