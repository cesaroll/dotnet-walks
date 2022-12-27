using System.Net.Security;

namespace Walks.API.Repositories;

public interface IUserRepository
{
    public Task<bool> AuthenticateAsync(string username, string password);
}