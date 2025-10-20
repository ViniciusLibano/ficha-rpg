using System.ComponentModel.DataAnnotations;

namespace RpgApi.Application.DTOs.GameSessions;

public class CreateGameSessionRequest
{
    [Required, MaxLength(100)]
    public string Name { get; set; }
    [Required]
    public int GameSystemId { get; set; }
}