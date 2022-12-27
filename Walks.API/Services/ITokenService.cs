using Walks.API.Models.DTOs;

namespace Walks.API.Services;

public interface ITokenService
{
    public Task<string> CreateTokenAsync(User user);
}