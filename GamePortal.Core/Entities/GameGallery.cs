namespace GamePortal.Core.Entities;

public class GameGallery : BaseEntity
{
    public int GameId { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string? Caption { get; set; }
    public int DisplayOrder { get; set; }
    
    // Navigation properties
    public virtual Game Game { get; set; } = null!;
}

