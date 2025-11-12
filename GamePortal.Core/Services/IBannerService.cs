using GamePortal.Core.Entities;

namespace GamePortal.Core.Services;

public interface IBannerService
{
    Task<IReadOnlyList<Banner>> GetAllAsync();
    Task<IReadOnlyList<Banner>> GetActiveByPositionAsync(BannerPosition position);
    Task<Banner?> GetByIdAsync(int id);
    Task<Banner> CreateAsync(Banner banner);
    Task UpdateAsync(Banner banner);
    Task DeleteAsync(int id);
}
