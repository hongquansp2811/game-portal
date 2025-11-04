using GamePortal.Core.Entities;
using GamePortal.Core.Interfaces;
using GamePortal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GamePortal.Infrastructure.Repositories;

public class GameRepository : Repository<Game>, IGameRepository
{
    public GameRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Game>> GetFeaturedGamesAsync(int count)
    {
        return await _dbSet
            .Where(g => g.IsFeatured && !g.IsDeleted)
            .OrderByDescending(g => g.CreatedAt)
            .Take(count)
            .Include(g => g.Category)
            .ToListAsync();
    }

    public async Task<IEnumerable<Game>> GetHotGamesAsync(int count)
    {
        return await _dbSet
            .Where(g => g.IsHot && !g.IsDeleted)
            .OrderByDescending(g => g.PlayCount)
            .Take(count)
            .Include(g => g.Category)
            .ToListAsync();
    }

    public async Task<IEnumerable<Game>> GetGamesByCategoryAsync(int categoryId, int skip = 0, int take = 10)
    {
        return await _dbSet
            .Where(g => g.CategoryId == categoryId && !g.IsDeleted)
            .OrderByDescending(g => g.CreatedAt)
            .Skip(skip)
            .Take(take)
            .Include(g => g.Category)
            .ToListAsync();
    }

    public async Task<IEnumerable<Game>> GetLatestGamesAsync(int count)
    {
        return await _dbSet
            .Where(g => !g.IsDeleted)
            .OrderByDescending(g => g.CreatedAt)
            .Take(count)
            .Include(g => g.Category)
            .ToListAsync();
    }

    public async Task<IEnumerable<Game>> SearchGamesAsync(string searchTerm)
    {
        return await _dbSet
            .Where(g => !g.IsDeleted && 
                (g.Title.Contains(searchTerm) || g.Description!.Contains(searchTerm)))
            .OrderByDescending(g => g.CreatedAt)
            .Include(g => g.Category)
            .ToListAsync();
    }

    public async Task<IEnumerable<Game>> GetAllGamesAsync(int skip = 0, int take = 50)
    {
        return await _dbSet
            .Where(g => !g.IsDeleted)
            .OrderByDescending(g => g.CreatedAt)
            .Skip(skip)
            .Take(take)
            .Include(g => g.Category)
            .ToListAsync();
    }
}

