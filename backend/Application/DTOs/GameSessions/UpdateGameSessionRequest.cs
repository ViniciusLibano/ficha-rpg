using System.ComponentModel.DataAnnotations;

namespace RpgApi.Application.DTOs.GameSessions;

public class UpdateGameSessionRequest
{
    [Required, MaxLength(100)]
    public string Name { get; set; }
}