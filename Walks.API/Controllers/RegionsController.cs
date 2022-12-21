using Microsoft.AspNetCore.Mvc;
using Walks.API.Models.DTO;
using Walks.API.Services;

namespace Walks.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RegionsController : ControllerBase
{
  private readonly IRegionService _regionService;

  public RegionsController(IRegionService regionService)
  {
    _regionService = regionService;
  }

  [HttpGet]
  public async Task<IActionResult> GetAllRegionsAsync()
  {
      var regionsDTO = await _regionService.GetAllAsync();
      return Ok(regionsDTO);
  }

  [HttpGet]
  [Route("{id:guid}")]
  public async Task<IActionResult> GetRegionAsync(Guid id) {
    var regionDTO = await _regionService.GetAsync(id);

    if (regionDTO == null)
      return NotFound();

    return Ok(regionDTO);
  }
}
