using System;
using AutoMapper;
using Walks.API.Models.DTOs.Requests;

namespace Walks.API.Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Models.Entities.RegionEntity, Models.DTOs.Region>()
                .ReverseMap();

            CreateMap<MutateRegionRequest, Models.Entities.RegionEntity>();
        }
    }
}
