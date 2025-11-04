namespace GamePortal.Core.DTOs;

public class UpdateGameDTO
{
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string ThumbnailUrl { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? FullDescription { get; set; }
    public int Rating { get; set; } = 5;
    public string GameType { get; set; } = "Online";
    public string? Platform { get; set; }
    public string? GameUrl { get; set; }
    public bool IsHot { get; set; }
    public bool IsFeatured { get; set; }
    public int CategoryId { get; set; }
}
