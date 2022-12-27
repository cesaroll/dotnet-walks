using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;
using Walks.API.Data;
using Walks.API.Models.Entities;

namespace Walks.API.Repositories;

public class UserRepository : IUserRepository
{
    private readonly WalksDbContext _walksDbContext;

    public UserRepository(WalksDbContext walksDbContext)
    {
        _walksDbContext = walksDbContext;
    }

    public async Task<Result<UserEntity>> GetAsync(string username, string password)
    {
        var user = await _walksDbContext.Users
            .Include(x => x.UserRoles)
            .ThenInclude(y => y.Role)
            .FirstOrDefaultAsync(user => user.Username.ToLower() == username.ToLower() &&
                                         user.Password == password);
        
        if (user == null)
        {
            var exception = new Exception("User not found exception");
            return new Result<UserEntity>(exception);
        }

        user.Password = "";

        return user;
    }
}