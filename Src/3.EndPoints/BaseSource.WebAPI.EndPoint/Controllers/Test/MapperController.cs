using AutoMapper;

namespace BaseSource.WebAPI.EndPoint.Controllers.Test;

public class MapperController : AuthorizeController
{
    [HttpGet("MapToModel")]
    public IActionResult MapToModel()
    {
        MapperEntity entity = new(){ Name = "Tajerbashi", Age = 20, Address= "Address 1"};
        var model = Factory.Mapper.Map<MapperEntity,MapperQueryModel>(entity);
        model.Name = "Kamran";
        model.Age = 25;
        MapperEntity entity1 = Factory.Mapper.Map<MapperQueryModel,MapperEntity>(model);
        return ReturnResponse(new
        {
            entity = entity,
            entity1 = entity1
        });
    }
}

public class MapperEntity
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
}

public class MapperQueryModel
{
    public string Name { get; set; }
    public int Age { get; set; }
}


public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<MapperEntity, MapperQueryModel>().ReverseMap();
    }
}
