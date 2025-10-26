using RpgApi.Application.DTOs.Account;

namespace RpgApi.Application.Services.Interfaces;

public interface IAccountService
{
    Task<AuthResult> RegisterAsync(RegisterUserRequest request);
    Task<AuthResult> LoginAsync(LoginRequest request);
    Task<UserResponse?> GetUserInfoAsync(string userId);
}