namespace BaseSource.Core.Application.UseCases.Identity.User.Handlers.Queries.GetById;

public class UserGetByIdProfile : Profile
{
    public UserGetByIdProfile()
    {
        CreateMap<UserEntity, UserGetByIdQueryModel>().ReverseMap();
    }
}
