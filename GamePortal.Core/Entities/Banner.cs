namespace GamePortal.Core.Entities;

public class Banner : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string? LinkUrl { get; set; }
    public string? Description { get; set; }
    public BannerPosition Position { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsActive { get; set; } = true;
}

public enum BannerPosition
{
    Top,
    Sidebar,
    Bottom,
    Inline
}

