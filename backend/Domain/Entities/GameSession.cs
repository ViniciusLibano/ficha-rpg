using System.Collections;

namespace RpgApi.Domain.Entities;

public class GameSession
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime ModifiedAt { get; set; } = DateTime.Now;
    
    public int GameMasterId { get; set; }
    public virtual User GameMaster { get; set; } = null!;
    
    public int GameSystemId { get; set; }
    public virtual GameSystem GameSystem { get; set; } = null!;
    
    public virtual ICollection<SessionPlayer> PlayersLink { get; set; } = new List<SessionPlayer>();
    
    public virtual ICollection<CharacterSheet> SessionSheets { get; set; } = new List<CharacterSheet>();
}