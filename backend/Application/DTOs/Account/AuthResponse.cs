namespace RpgApi.Application.DTOs.Account;

public class AuthResponse
{
    public string Token { get; set; }
    public UserResponse User { get; set; }
}