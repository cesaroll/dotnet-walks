using Microsoft.AspNetCore.Mvc;
using Walks.API.Data;
using Walks.API.Models.Domain;
using Walks.API.Repositories;

namespace Walks.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RegionsController : ControllerBase
{
    private readonly IRegionRepository _regionsRepo;

  public RegionsController(IRegionRepository regionsRepo)
  {
    _regionsRepo = regionsRepo;
  }

  [HttpGet]
    public IActionResult GetAllRegions()
    {
        return Ok(_regionsRepo.GetAll());
    }
}
