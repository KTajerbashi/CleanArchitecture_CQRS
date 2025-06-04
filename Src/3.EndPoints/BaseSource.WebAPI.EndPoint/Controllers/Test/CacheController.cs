namespace BaseSource.WebAPI.EndPoint.Controllers.Test;

public class RequestParameter
{
    public string Key { get; set; }
    public string Value { get; set; }
}


public class CacheController : AuthorizeController
{
    [HttpPost("Set")]
    public IActionResult Set(RequestParameter parameter)
    {
        Factory.Cache.Add(parameter.Key, parameter.Value, DateTime.Now.AddMinutes(10), DateTime.Now.TimeOfDay);
        return ReturnResponse($"Added To Table => {parameter.Key} : {parameter.Value}");
    }

    [HttpGet("Get")]
    public IActionResult Get(string key)
    {
        var value = Factory.Cache.Get<string>(key);
        return ReturnResponse($"Read From Table => {key} : {value}");
    }

    [HttpDelete("Remove")]
    public IActionResult Remove(string key)
    {
        var value = Factory.Cache.Get<string>(key);
        Factory.Cache.RemoveCache(key);

        return ReturnResponse($"Removed From Table => {key} : {value}");
    }

}
