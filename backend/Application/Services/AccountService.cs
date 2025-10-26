using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using RpgApi.Application.DTOs.Account;
using RpgApi.Application.Services.Interfaces;
using RpgApi.Domain.Entities;

namespace RpgApi.Application.Services;

public class AccountService(
    UserManager<User> userManager,
    SignInManager<User> signInManager,
    ITokenService tokenService) : IAccountService
{
    public async Task<AuthResult> RegisterAsync(RegisterUserRequest request)
    {
        var userExists = await userManager.FindByNameAsync(request.UserName);
        
        if (userExists != null)
            return AuthResult.Failure("Username is already taken");

        var user = new User
        {
            UserName = request.UserName,
            Email = request.Email,
            FullName = request.FullName,
            Birthday = request.Birthday,
            CreatedAt = DateTime.UtcNow
        };
        
        var result = await userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
            return AuthResult.Failure(result.Errors.Select(e => e.Description));
        
        return await LoginAsync(new()
        {
            EmailOrUserName = request.Email,
            Password = request.Password
        });
    }

    public async Task<AuthResult> LoginAsync(LoginRequest request)
    {
        var user = await userManager.FindByEmailAsync(request.EmailOrUserName)
                   ?? await userManager.FindByNameAsync(request.EmailOrUserName);

        if (user == null)
            return AuthResult.Failure("Credentials are incorrect!");
        
        var result = await signInManager
            .CheckPasswordSignInAsync(user, request.Password, false);

        if (!result.Succeeded)
            return AuthResult.Failure("Credentials are incorrect!");
        
        var token = tokenService.GenerateToken(user);

        var userResponse = new UserResponse
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            FullName = user.FullName,
        };

        return AuthResult.Success(new AuthResponse
        {
            Token = token,
            User = userResponse
        });
    }

    public async Task<UserResponse?> GetUserInfoAsync(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        
        if (user == null) return null;
        
        return new UserResponse
        {
            Id = user.Id,
            FullName = user.FullName,
            UserName = user.UserName,
            Email = user.Email
        };
    }
}