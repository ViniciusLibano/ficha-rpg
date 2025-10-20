using System.ComponentModel.DataAnnotations;

namespace RpgApi.Application.DTOs.GameSessions;

public class AddPlayerRequest
{
    [Required, EmailAddress]
    public string PlayerEmail { get; set; }
}