using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc;
using Walks.API.Models.DTOs.Requests;
using Walks.API.Services;

namespace Walks.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : Controller
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> LoginAsync(LoginRequest loginRequest)
    {
        var result = await _userService.AuthenticateAsync(loginRequest);

        return result.Match<IActionResult>(jwt =>
        {
            return Ok(jwt);
        }, exception =>
        {
            // TODO: add validations
            
            if (exception is AuthenticationException)
            {
                return Unauthorized();
            }

            return StatusCode(500);
        });
    }
}