namespace GamePortal.Core.DTOs;

public class CategoryDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string? IconUrl { get; set; }
    public int GameCount { get; set; }
}

