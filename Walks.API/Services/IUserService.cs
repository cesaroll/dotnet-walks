using LanguageExt.Common;
using Walks.API.Models.DTOs.Requests;

namespace Walks.API.Services;

public interface IUserService
{
    public Task<Result<string>> AuthenticateAsync(LoginRequest loginRequest);
}