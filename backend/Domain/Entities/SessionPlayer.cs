namespace RpgApi.Domain.Entities;

public class SessionPlayer
{
    public int SessionId { get; set; }
    public GameSession Session { get; set; } = null!;
    
    public int PlayerId { get; set; }
    public User Player { get; set; } = null!;
}