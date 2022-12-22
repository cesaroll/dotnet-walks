using AutoMapper;
using Walks.API.Models.DTOs;
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

    public async Task<IList<Region> > GetAllAsync()
    {
        var regions = await _regionRepo.GetAllAsync();
        return _mapper.Map<List<Models.DTOs.Region>>(regions);
    }

    public async Task<Region> GetAsync(Guid id)
    {
        var region = await _regionRepo.GetAsync(id);
        return _mapper.Map<Models.DTOs.Region>(region);
    }

    public async Task<Region> AddAsync(AddRegionRequest addRegionRequest) {
      var region = _mapper.Map<Models.Entities.RegionEntity>(addRegionRequest);

      region = await _regionRepo.AddAsync(region);
      return _mapper.Map<Models.DTOs.Region>(region);
    }

    public async Task DeleteAsync(Guid id) {
      await _regionRepo.DeleteAsync(id);
    }

    public async Task<Region> UpdateAsync(Guid id, UpdateRegionRequest updateRegionRequest) {
      var region = _mapper.Map<Models.Entities.RegionEntity>(updateRegionRequest);
      region.Id = id;

      region = await _regionRepo.UpdateAsync(region);
      return _mapper.Map<Models.DTOs.Region>(region);
    }
  }
}
