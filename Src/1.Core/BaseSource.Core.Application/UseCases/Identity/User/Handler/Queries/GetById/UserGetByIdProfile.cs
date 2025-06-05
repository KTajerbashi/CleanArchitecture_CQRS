namespace BaseSource.Core.Application.UseCases.Identity.User.Handler.Queries.GetById;

public class UserGetByIdProfile : Profile
{
    public UserGetByIdProfile()
    {
        CreateMap<UserEntity, UserGetByIdQueryModel>().ReverseMap();
    }
}
