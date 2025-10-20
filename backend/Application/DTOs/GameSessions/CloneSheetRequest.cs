using System.ComponentModel.DataAnnotations;

namespace RpgApi.Application.DTOs.GameSessions;

public class CloneSheetRequest
{
    [Required]
    public int CharacterSheetIdToClone { get; set; }
}