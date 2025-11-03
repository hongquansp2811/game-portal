namespace GamePortal.Core.Entities;

public class TipGuide : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string ThumbnailUrl { get; set; } = string.Empty;
    public string? Excerpt { get; set; }
    public string Content { get; set; } = string.Empty;
    public bool IsFeatured { get; set; }
    public int ViewCount { get; set; }
    
    // Navigation properties
    public virtual ICollection<TipGuideCategory> Categories { get; set; } = new List<TipGuideCategory>();
}

public class TipGuideCategory : BaseEntity
{
    public int TipGuideId { get; set; }
    public int CategoryId { get; set; }
    
    // Navigation properties
    public virtual TipGuide TipGuide { get; set; } = null!;
    public virtual Category Category { get; set; } = null!;
}

