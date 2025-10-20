using System.ComponentModel.DataAnnotations;

namespace RpgApi.Application.DTOs.Account;

public class RegisterUserRequest
{
    [Required, EmailAddress]
    public string Email { get; set; } = null!;

    [Required, MinLength(8), MaxLength(25)]
    public string UserName { get; set; } = null!;

    [Required, MinLength(8), MaxLength(20)]
    public string Password { get; set; } = null!;
    
    [MinLength(15), MaxLength(100)]
    public string? FullName { get; set; }
    
    [Required]
    public DateTime Birthday { get; set; }
}