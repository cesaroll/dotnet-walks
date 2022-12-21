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

    public async Task<IList<RegionDTO> > GetAllAsync()
    {
        var regions = await _regionRepo.GetAllAsync();
        return _mapper.Map<List<Models.DTO.RegionDTO>>(regions);
    }

    public async Task<RegionDTO> GetAsync(Guid id)
    {
        var region = await _regionRepo.GetAsync(id);
        return _mapper.Map<Models.DTO.RegionDTO>(region);
    }

    public async Task<RegionDTO> AddAsync(AddRegionRequest addRegionRequest) {
      var region = _mapper.Map<Models.Domain.Region>(addRegionRequest);

      region = await _regionRepo.AddAsync(region);
      return _mapper.Map<Models.DTO.RegionDTO>(region);
    }
  }
}
