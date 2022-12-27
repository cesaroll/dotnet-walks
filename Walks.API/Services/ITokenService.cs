using Walks.API.Models.Entities;

namespace Walks.API.Services;

public interface ITokenService
{
    public Task<string> CreateTokenAsync(UserEntity user);
}