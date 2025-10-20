using System.Collections;

namespace RpgApi.Domain.Entities;

public class GameSystem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    
    public virtual ICollection<SheetModel> SheetModels { get; set; } = new List<SheetModel>();
    public virtual ICollection<GameSession> GameSessions { get; set; } = new List<GameSession>();   
}