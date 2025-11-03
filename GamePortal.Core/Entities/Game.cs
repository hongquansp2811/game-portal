namespace GamePortal.Core.Entities;

public class Game : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string ThumbnailUrl { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? FullDescription { get; set; }
    public int Rating { get; set; } // 1-5 stars
    public int PlayCount { get; set; }
    public string GameType { get; set; } = "Online"; // Online, Review, Download
    public string? Platform { get; set; } // Desktop, Tablet, Mobile
    public string? GameUrl { get; set; }
    public bool IsHot { get; set; }
    public bool IsFeatured { get; set; }
    
    // Foreign keys
    public int CategoryId { get; set; }
    
    // Navigation properties
    public virtual Category Category { get; set; } = null!;
    public virtual ICollection<GameGallery> Galleries { get; set; } = new List<GameGallery>();
    public virtual ICollection<GameReview> Reviews { get; set; } = new List<GameReview>();
}

