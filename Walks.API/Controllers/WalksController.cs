using Microsoft.AspNetCore.Mvc;
using Walks.API.Models.DTOs.Requests;
using Walks.API.Services;

namespace Walks.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WalksController : Controller
{
    private readonly IWalkService _walkService;

    public WalksController(IWalkService walkService)
    {
        _walkService = walkService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWalksAsync()
    {
        var walks = await _walkService.GetAllAsync();
        return Ok(walks);
    }

    [HttpGet]
    [Route("{id:guid}")]
    [ActionName("GetWalkAsync")]
    public async Task<IActionResult> GetWalkAsync(Guid id)
    {
        var walk = await _walkService.GetAsync(id);
        return Ok(walk);
    }

    [HttpPost]
    public async Task<IActionResult> AddWalkAsync(MutateWalkRequest mutateWalkRequest)
    {
        var walk = await _walkService.AddAsync(mutateWalkRequest);

        return CreatedAtAction(nameof(GetWalkAsync), new { Id = walk.Id }, walk);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateWalkAsync(
        [FromRoute] Guid id, 
        [FromBody] MutateWalkRequest mutateWalkRequest)
    {
        var walk = await _walkService.UpdateAsync(id, mutateWalkRequest);
        return Ok(walk);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task DeleteWalkAsync(Guid id)
    {
        await _walkService.DeleteAsync(id);
    }
}