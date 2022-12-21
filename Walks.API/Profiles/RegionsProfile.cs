using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Walks.API.Profiles
{
    public class RegionsProfile : Profile
    {
        public RegionsProfile()
        {
            CreateMap<Models.Domain.Region, Models.DTO.RegionDTO>()
                .ReverseMap();

            CreateMap<Models.DTO.AddRegionRequest, Models.Domain.Region>()
                .ForMember(dest => dest.Id, act => act.AddTransform(src => Guid.NewGuid()));
        }
    }
}
