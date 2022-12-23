using AutoMapper;
using Walks.API.Models.DTOs.Requests;

namespace Walks.API.Profiles;

public class WalkProfile : Profile
{
    public WalkProfile()
    {
        CreateMap<Models.Entities.WalkEntity, Models.DTOs.Walk>()
            .ReverseMap();

        CreateMap<MutateWalkRequest, Models.Entities.WalkEntity>();
    }
}