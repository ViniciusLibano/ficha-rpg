using System.Collections;
using Microsoft.AspNetCore.Identity;

namespace RpgApi.Domain.Entities;

public class User : IdentityUser<int>
{
    public string? FullName { get; set; }
    public DateTime Birthday { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime ModifiedAt { get; set; } = DateTime.Now;
    public DateTime LastLogin { get; set; }
    
    public virtual ICollection<GameSession> GmedSessions { get; set; } = new List<GameSession>();
    
    public virtual ICollection<SessionPlayer> SessionsLink { get; set; } = new List<SessionPlayer>();
    
    public virtual ICollection<CharacterSheet> CharacterSheets { get; set; } = new List<CharacterSheet>();
}