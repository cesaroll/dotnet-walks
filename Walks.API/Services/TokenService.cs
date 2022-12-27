using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Walks.API.Models.DTOs;

namespace Walks.API.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Task<string> CreateTokenAsync(User user)
    {
        // Create Claims
        var claims = new List<Claim>();
        claims.Add(new Claim(ClaimTypes.GivenName, user.FirstName));
        claims.Add(new Claim(ClaimTypes.Surname, user.LastName));
        claims.Add(new Claim(ClaimTypes.Email, user.Email));
        
        // Loop into user roles
        user.Roles?.ForEach(role =>
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        });
        
        // create token
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"]!,
            _configuration["Jwt:Audience"]!,
            claims,
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials: credentials
            );

        return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
    }
}