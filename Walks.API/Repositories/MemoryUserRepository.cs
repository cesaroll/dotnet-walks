using LanguageExt.Common;
using Walks.API.Models.Entities;

namespace Walks.API.Repositories;

public class MemoryUserRepository : IUserRepository
{
    private static readonly List<UserEntity> _users = new List<UserEntity>()
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
            Username = "cesar", Password = "start123",
            Roles = new List<string>() {"reader", "writer"}
        }
    };
    
    public async Task<Result<UserEntity>> GetAsync(string username, string password)
    {
        var user = _users.FirstOrDefault(x =>
            x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) &&
            x.Password == password);

        if (user == null)
        {
            var exception = new Exception("User not found exception");
            return new Result<UserEntity>(exception);
        }

        return user;
    }
}