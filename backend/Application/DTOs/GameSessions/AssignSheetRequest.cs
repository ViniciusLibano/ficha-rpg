using System.ComponentModel.DataAnnotations;

namespace RpgApi.Application.DTOs.GameSessions;

public class AssignSheetRequest
{
    [Required]
    public int CharacterSheetId { get; set; }
}