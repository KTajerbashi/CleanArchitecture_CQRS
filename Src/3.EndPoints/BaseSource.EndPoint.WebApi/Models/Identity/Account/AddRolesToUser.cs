namespace BaseSource.EndPoint.WebApi.Models.Identity.Account;

public class CreateRole
{
    public string Name { get; set; }
}
public class AddRolesToUser
{
    public string UserName { get; set; }
    public List<string> Roles { get; set; }
}

