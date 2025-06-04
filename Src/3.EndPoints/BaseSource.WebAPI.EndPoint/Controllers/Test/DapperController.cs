using BaseSource.Utilities.Models;

namespace BaseSource.WebAPI.EndPoint.Controllers.Test;
public class UserModel: QueryModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}

public class DapperController : AuthorizeController
{
    [HttpGet("Execute")]
    public async Task<IActionResult> Execute()
    {
        var dataA = await Factory.Query.ReadQueryAsync<UserModel>("SELECT * FROM [Identity].[Users]",new {});
        var dataB = await Factory.Query.ReadQueryAsync<UserModel>("SELECT * FROM [Identity].[Users] WHERE Id = @Id",new {Id = 1});
        var dataC = dataA.ToList();
        dataC.AddRange(dataB);
        return ReturnResponse(dataC);
    }
}
