using BaseSource.Utilities.SerializerProvider;

namespace BaseSource.WebAPI.EndPoint.Controllers.Test;
public class SerializerController : AuthorizeController
{
    private readonly IJsonSerializer _jsonSerializer;

    public SerializerController(IJsonSerializer jsonSerializer)
    {
        _jsonSerializer = jsonSerializer;
    }

    [HttpGet("Serialize")]
    public IActionResult Serialize()
    {
        return ReturnResponse(
            _jsonSerializer.Serialize(
                new Model
                {
                    Name = "BaseSource",
                    Version = "1.0.0",
                    Description = "BaseSource WebAPI EndPoint Serializer Test"
                }));
    }

    [HttpGet("Deserialize")]
    public IActionResult Deserialize()
    {
        var temp = _jsonSerializer.Serialize(
                new Model
                {
                    Name = "BaseSource",
                    Version = "1.0.0",
                    Description = "BaseSource WebAPI EndPoint Serializer Test"
                });
        return ReturnResponse(_jsonSerializer.Deserialize<Model>(temp));
    }

}
class Model
{
    public string Name { get; set; }
    public string Version { get; set; }
    public string Description { get; set; }
}