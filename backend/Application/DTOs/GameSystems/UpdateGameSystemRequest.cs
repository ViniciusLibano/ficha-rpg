using System.ComponentModel.DataAnnotations;

namespace RpgApi.Application.DTOs.GameSystems;

public class UpdateGameSystemRequest
{
    [Required, MaxLength(20)]
    public string Name { get; set; } = null!;
    
    [MaxLength(2000)]
    public string? Description { get; set; }
}