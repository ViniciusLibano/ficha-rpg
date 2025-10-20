using System.ComponentModel.DataAnnotations;

namespace RpgApi.Application.DTOs.SheetModels;

public class CreateSheetModelRequest
{
    [Required]
    public int GameSystemId { get; set; }
    
    [Required, MaxLength(100)]
    public string Name { get; set; } = null!;
    
    [MaxLength(2000)]
    public string? Description { get; set; }
    
    [Required]
    public string DocumentTemplateJson { get; set; } = null!;
}