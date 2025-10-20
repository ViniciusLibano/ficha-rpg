using RpgApi.Application.DTOs.Account;

namespace RpgApi.Application.DTOs.GameSessions;

public class GameSessionResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string GameSystemName { get; set; }
    public UserResponse GameMaster { get; set; }
}