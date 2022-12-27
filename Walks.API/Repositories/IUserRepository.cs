using LanguageExt.Common;
using Walks.API.Models.Entities;

namespace Walks.API.Repositories;

public interface IUserRepository
{
    public Task<Result<UserEntity>> GetAsync(string username, string password);
}