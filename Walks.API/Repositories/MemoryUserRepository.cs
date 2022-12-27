using Walks.API.Models.Entities;

namespace Walks.API.Repositories;

public class MemoryUserRepository : IUserRepository
{
    private static List<UserEntity> _users = new List<UserEntity>()
    {
        new UserEntity()
        {
            FirstName = "Amy", LastName = "Reader", Email = "amy.reader@walks.com", Id = Guid.NewGuid(),
            Username = "amy", Password = "cde123",
            Roles = new List<string>() {"reader"}
        },
        new UserEntity()
        {
            FirstName = "Cesar", LastName = "Writer", Email = "cesar.writer@walks.com", Id = Guid.NewGuid(),
            Username = "cesar", Password = "abc123",
            Roles = new List<string>() {"reader", "writer"}
        }
    };
    
    public async Task<bool> AuthenticateAsync(string username, string password)
    {
        return _users.Exists(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) &&
                           x.Password == password);
    }
}