using System.ComponentModel.DataAnnotations;

namespace GamePortal.Core.DTOs;

public class CreateGameDTO
{
    [Required(ErrorMessage = "Title is required")]
    [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
    public string Title { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Slug is required")]
    [StringLength(200, ErrorMessage = "Slug cannot exceed 200 characters")]
    [RegularExpression(@"^[a-z0-9]+(?:-[a-z0-9]+)*$", ErrorMessage = "Slug must be lowercase, alphanumeric with hyphens only")]
    public string Slug { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Thumbnail URL is required")]
    public string ThumbnailUrl { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    public string? FullDescription { get; set; }
    
    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
    public int Rating { get; set; } = 5;
    
    public string GameType { get; set; } = "Online";
    public string? Platform { get; set; }
    
    [Required(ErrorMessage = "Game URL is required")]
    public string? GameUrl { get; set; }
    
    public bool IsHot { get; set; }
    public bool IsFeatured { get; set; }
    
    [Range(1, int.MaxValue, ErrorMessage = "Please select a category")]
    public int CategoryId { get; set; }
}
