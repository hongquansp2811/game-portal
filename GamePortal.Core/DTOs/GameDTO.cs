namespace GamePortal.Core.DTOs;

public class GameDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string ThumbnailUrl { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int Rating { get; set; }
    public int PlayCount { get; set; }
    public string GameType { get; set; } = string.Empty;
    public string? Platform { get; set; }
    public string? GameUrl { get; set; }
    public bool IsHot { get; set; }
    public bool IsFeatured { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string CategorySlug { get; set; } = string.Empty;
}

public class GameDetailDTO : GameDTO
{
    public string? FullDescription { get; set; }
    public List<string> GalleryImages { get; set; } = new();
}

