using GamePortal.Core.Entities;

namespace GamePortal.Core.Interfaces;

public interface IGameRepository : IRepository<Game>
{
    Task<IEnumerable<Game>> GetFeaturedGamesAsync(int count);
    Task<IEnumerable<Game>> GetHotGamesAsync(int count);
    Task<IEnumerable<Game>> GetGamesByCategoryAsync(int categoryId, int skip = 0, int take = 10);
    Task<IEnumerable<Game>> GetLatestGamesAsync(int count);
    Task<IEnumerable<Game>> SearchGamesAsync(string searchTerm);
    Task<IEnumerable<Game>> GetAllGamesAsync(int skip = 0, int take = 50);
}

