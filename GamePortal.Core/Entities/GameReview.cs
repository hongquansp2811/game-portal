namespace GamePortal.Core.Entities;

public class GameReview : BaseEntity
{
    public int GameId { get; set; }
    public string PlayerName { get; set; } = string.Empty;
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public bool IsVerified { get; set; }
    
    // Navigation properties
    public virtual Game Game { get; set; } = null!;
}

