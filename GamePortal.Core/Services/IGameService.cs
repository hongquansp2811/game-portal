using GamePortal.Core.DTOs;

namespace GamePortal.Core.Services;

public interface IGameService
{
    Task<IEnumerable<GameDTO>> GetFeaturedGamesAsync(int count = 10);
    Task<IEnumerable<GameDTO>> GetHotGamesAsync(int count = 10);
    Task<IEnumerable<GameDTO>> GetLatestGamesAsync(int count = 20);
    Task<IEnumerable<GameDTO>> GetGamesByCategoryAsync(int categoryId, int skip = 0, int take = 10);
    Task<GameDetailDTO?> GetGameBySlugAsync(string slug);
    Task<IEnumerable<GameDTO>> SearchGamesAsync(string searchTerm);
}

