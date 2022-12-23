using Microsoft.AspNetCore.Mvc;
using Walks.API.Models.DTOs.Requests;
using Walks.API.Services;

namespace Walks.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WalkDifficultiesController : Controller
{
    private readonly IWalkDifficultyService _walkDifficultyService;

    public WalkDifficultiesController(IWalkDifficultyService walkDifficultyService)
    {
        _walkDifficultyService = walkDifficultyService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWalkDifficultiesAsync()
    {
        var walkDifficulties = await _walkDifficultyService.GetAllAsync();
        return Ok(walkDifficulties);
    }

    [HttpGet]
    [Route("{id:guid}")]
    [ActionName("GetWalkDifficultyAsync")]
    public async Task<IActionResult> GetWalkDifficultyAsync(Guid id)
    {
        var walkDifficulty = await _walkDifficultyService.GetAsync(id);
        return Ok(walkDifficulty);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task DeleteWalkDifficultyAsync(Guid id)
    {
        await _walkDifficultyService.DeleteAsync(id);
    }

    [HttpPost]
    public async Task<IActionResult> AddWalkDifficultyAsync(MutateWalkDifficultyRequest mutateWalkDifficultyRequest)
    {
        var walkDifficulty = await _walkDifficultyService.AddAsync(mutateWalkDifficultyRequest);

        return CreatedAtAction(
            nameof(GetWalkDifficultyAsync), 
            new {Id = walkDifficulty.Id}, 
            walkDifficulty);
    }
    
    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateWalkDifficultyAsync(
        [FromRoute] Guid id,
        [FromBody] MutateWalkDifficultyRequest mutateWalkDifficultyRequest)
    {
        var walkDifficulty = await _walkDifficultyService.UpdateAsync(id, mutateWalkDifficultyRequest);
        return Ok(walkDifficulty);
    }
}