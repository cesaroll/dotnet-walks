using System.Security.Authentication;
using LanguageExt.Common;
using Microsoft.AspNetCore.Http.HttpResults;
using Walks.API.Models.DTOs.Requests;
using Walks.API.Repositories;

namespace Walks.API.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<string>> AuthenticateAsync(LoginRequest loginRequest)
    {
        var isUserAuthenticated = await _userRepository.AuthenticateAsync(loginRequest.Username, loginRequest.Password);

        if (!isUserAuthenticated)
        {
            var authException = new AuthenticationException("Unable to authenticate user.");
            return new Result<string>(authException);
        }

        return "sadsfdsf43t4f34rf"; // TODO: use JWT instead
    }
}