namespace RpgApi.Domain.Entities;

public class SheetModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    
    public string DocumentTemplateJson { get; set; } = "{}";
    
    public int GameSystemId { get; set; }
    public virtual GameSystem GameSystem { get; set; } = null!;
    
    public virtual ICollection<CharacterSheet> CharacterSheets { get; set; } = new List<CharacterSheet>();
}