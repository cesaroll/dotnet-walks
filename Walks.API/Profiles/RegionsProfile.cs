using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Walks.API.Profiles
{
    public class RegionsProfile : Profile
    {
        public RegionsProfile()
        {
            CreateMap<Models.Entities.RegionEntity, Models.DTOs.Region>()
                .ReverseMap();

            CreateMap<Models.DTOs.AddRegionRequest, Models.Entities.RegionEntity>()
                .ForMember(dest => dest.Id, act => act.AddTransform(src => Guid.NewGuid()));

            CreateMap<Models.DTOs.UpdateRegionRequest, Models.Entities.RegionEntity>();
        }
    }
}
