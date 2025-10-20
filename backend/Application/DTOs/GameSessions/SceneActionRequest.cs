using System.ComponentModel.DataAnnotations;

namespace RpgApi.Application.DTOs.GameSessions;

public class SceneActionRequest
{
    [Required]
    public int CharacterSheetId { get; set; }
}