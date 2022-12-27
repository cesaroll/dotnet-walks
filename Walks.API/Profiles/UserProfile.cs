using AutoMapper;

namespace Walks.API.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<Models.Entities.UserEntity, Models.DTOs.User>();
    }
}