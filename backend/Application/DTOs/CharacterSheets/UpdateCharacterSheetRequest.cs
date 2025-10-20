using System.ComponentModel.DataAnnotations;
using RpgApi.Domain.Enums;

namespace RpgApi.Application.DTOs.CharacterSheets;

public class UpdateCharacterSheetRequest
{
    [Required, MaxLength(150)]
    public string Name { get; set; }
    public bool IsNPC { get; set; }
    public NpcAllegiance Allegiance { get; set; }
    public string SheetDataJson { get; set; }
}