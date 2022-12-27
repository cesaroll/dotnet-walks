using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Walks.API.Models.DTOs.Requests;
using Walks.API.Services;

namespace Walks.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RegionsController : Controller
{
  private readonly IRegionService _regionService;

  public RegionsController(IRegionService regionService)
  {
    _regionService = regionService;
  }

  [HttpGet]
  public async Task<IActionResult> GetAllRegionsAsync()
  {
      var regions = await _regionService.GetAllAsync();
      return Ok(regions);
  }

  [HttpGet]
  [Route("{id:guid}")]
  [ActionName("GetRegionAsync")]
  public async Task<IActionResult> GetRegionAsync(Guid id) {
    var region = await _regionService.GetAsync(id);

    // if (region == null) TODO: move to middleware
    //   return NotFound();

    return Ok(region);
  }

  [HttpPost]
  [Authorize]
  public async Task<IActionResult> AddRegionAsync(MutateRegionRequest mutateRegionRequest) {
    var region = await _regionService.AddAsync(mutateRegionRequest);

    return CreatedAtAction(nameof(GetRegionAsync), new { Id = region.Id }, region);
  }

  [HttpDelete]
  [Route("{id:guid}")]
  [Authorize]
  public async Task DeleteRegionAsync(Guid id) {
    await _regionService.DeleteAsync(id);
  }

  [HttpPut]
  [Route("{id:guid}")]
  [Authorize]
  public async Task<IActionResult> UpdateRegionAsync(
    [FromRoute] Guid id,
    [FromBody] MutateRegionRequest mutateRegionRequest) {
      var region = await _regionService.UpdateAsync(id, mutateRegionRequest);

      // if (region == null) TODO: move to middleware
      //   return NotFound();

      return Ok(region);
  }
}
