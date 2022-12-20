using System;
using AutoMapper;
using Walks.API.Models.DTO;
using Walks.API.Repositories;

namespace Walks.API.Services
{
  public class RegionService : IRegionService
  {
    private readonly IRegionRepository _regionRepo;

    private readonly IMapper _mapper;

    public RegionService(IRegionRepository regionRepo, IMapper mapper)
    {
      _regionRepo = regionRepo;
      _mapper = mapper;
    }

    public IList<RegionDTO> GetAll()
    {
        var regions = _regionRepo.GetAll();
        return _mapper.Map<List<Models.DTO.RegionDTO>>(regions);
    }
  }
}
