using AutoMapper;
using Walks.API.Models.DTOs.Requests;

namespace Walks.API.Profiles;

public class WalkDifficultyProfile : Profile
{
    public WalkDifficultyProfile()
    {
        CreateMap<Models.Entities.WalkDifficultyEntity, Models.DTOs.WalkDifficulty>()
            .ReverseMap();

        CreateMap<MutateWalkDifficultyRequest, Models.Entities.WalkDifficultyEntity>();
    }
}