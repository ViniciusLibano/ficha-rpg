using RpgApi.Domain.Enums;

namespace RpgApi.Domain.Entities;

public class CharacterSheet
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    
    public bool IsNpc { get; set; }
    public NpcAllegiance Allegiance { get; set; } = NpcAllegiance.Neutral;
    public bool IsActiveInScene { get; set; } = false;
    
    public bool AllowedGmEdit { get; set; } = true;
    
    public string SheetDataJson { get; set; } = null!;
    
    public int OwnerUserId { get; set; }
    public virtual User Owner { get; set; } = null!;
    
    public int SheetModelId { get; set; }
    public virtual SheetModel SheetModel { get; set; } = null!;
    
    public int? GameSessionId { get; set; }
    public virtual GameSession? GameSession { get; set; }
}