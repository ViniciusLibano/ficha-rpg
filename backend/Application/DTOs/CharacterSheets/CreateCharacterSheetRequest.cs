using System.ComponentModel.DataAnnotations;
using RpgApi.Domain.Enums;

namespace RpgApi.Application.DTOs.CharacterSheets;

public class CreateCharacterSheetRequest
{
    [Required, MaxLength(150)]
    public string Name { get; set; } = null!;
    
    [Required]
    public int SheetModelId { get; set; }
    
    public bool IsNPC { get; set; }
    
    public NpcAllegiance Allegiance { get; set; }
}