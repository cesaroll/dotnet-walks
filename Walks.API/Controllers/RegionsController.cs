using Microsoft.AspNetCore.Mvc;
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
    public async Task<IActionResult> GetAllRegions()
    {
        var regionsDTO = await _regionService.GetAllAsync();
        return Ok(regionsDTO);
    }
}
