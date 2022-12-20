using System;
using AutoMapper;

namespace Walks.API.Profiles
{
    public class RegionsProfile : Profile
    {
        public RegionsProfile()
        {
            CreateMap<Models.Domain.Region, Models.DTO.RegionDTO>()
                .ReverseMap();
        }
    }
}
