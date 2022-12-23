using Microsoft.AspNetCore.Mvc;
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
}