using System.Security.Authentication;
using AutoMapper;
using LanguageExt.Common;
using Microsoft.AspNetCore.Http.HttpResults;
using Walks.API.Models.DTOs.Requests;
using Walks.API.Models.Entities;
using Walks.API.Repositories;

namespace Walks.API.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, ITokenService tokenService, IMapper mapper)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
        _mapper = mapper;
    }

    public async Task<Result<string>> AuthenticateAsync(LoginRequest loginRequest)
    {
        var result = await _userRepository.GetAsync(loginRequest.Username, loginRequest.Password);

        return await result.Match<Task<Result<string>>>(  async userEntity =>
        {
            var token = await _tokenService.CreateTokenAsync(userEntity);
            return token;
        }, exception =>
        {
            var authException = new AuthenticationException("Unable to authenticate user.");
            return Task.FromResult(new Result<string>(authException));
        });
    }
}