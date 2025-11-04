using GamePortal.Core.Entities;
using GamePortal.Core.Interfaces;
using GamePortal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GamePortal.Infrastructure.Repositories;

public class BannerRepository : Repository<Banner>, IBannerRepository
{
    public BannerRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Banner>> GetActiveBannersAsync()
    {
        return await _dbSet
            .Where(b => b.IsActive && !b.IsDeleted)
            .OrderBy(b => b.DisplayOrder)
            .ToListAsync();
    }

    public async Task<IEnumerable<Banner>> GetBannersByPositionAsync(BannerPosition position)
    {
        return await _dbSet
            .Where(b => b.Position == position && b.IsActive && !b.IsDeleted)
            .OrderBy(b => b.DisplayOrder)
            .ToListAsync();
    }
}
