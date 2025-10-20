using System.ComponentModel.DataAnnotations;

namespace RpgApi.Application.DTOs.Account;

public class LoginRequest
{
    [Required]
    public string EmailOrUserName { get; set; } = null!;
    
    [Required]
    public string Password { get; set; } = null!;
}