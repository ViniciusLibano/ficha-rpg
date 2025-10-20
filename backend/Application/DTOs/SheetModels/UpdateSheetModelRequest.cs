using System.ComponentModel.DataAnnotations;

namespace RpgApi.Application.DTOs.SheetModels;

public class UpdateSheetModelRequest
{
    [Required, MaxLength(100)]
    public string Name { get; set; }
    
    [MaxLength(2000)]
    public string? Description { get; set; }
    
    [Required]
    public string DocumentTemplateJson { get; set; }
}