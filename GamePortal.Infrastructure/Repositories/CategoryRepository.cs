using GamePortal.Core.Entities;
using GamePortal.Core.Interfaces;
using GamePortal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GamePortal.Infrastructure.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Category>> GetActiveCategoriesAsync()
    {
        return await _dbSet
            .Where(c => c.IsActive && !c.IsDeleted)
            .OrderBy(c => c.DisplayOrder)
            .ToListAsync();
    }

    public async Task<Category?> GetBySlugAsync(string slug)
    {
        return await _dbSet
            .FirstOrDefaultAsync(c => c.Slug == slug && !c.IsDeleted);
    }
}

