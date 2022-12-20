using Microsoft.AspNetCore.Mvc;
using Walks.API.Data;
using Walks.API.Models.Domain;

namespace Walks.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RegionsController : ControllerBase
{
    private readonly WalksDbContext _dbContext;

    public RegionsController(WalksDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult GetAllRegions()
    {
        return Ok(_dbContext.Regions.ToList());
    }
}