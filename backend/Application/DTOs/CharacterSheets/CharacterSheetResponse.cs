using RpgApi.Application.DTOs.Account;

namespace RpgApi.Application.DTOs.CharacterSheets;

public class CharacterSheetResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string SheetDataJson { get; set; }
    public UserResponse Owner { get; set; }
    public int? GameSessionId { get; set; }
}