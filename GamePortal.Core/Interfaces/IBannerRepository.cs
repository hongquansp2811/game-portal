using GamePortal.Core.Entities;

namespace GamePortal.Core.Interfaces;

public interface IBannerRepository : IRepository<Banner>
{
    Task<IEnumerable<Banner>> GetActiveBannersAsync();
    Task<IEnumerable<Banner>> GetBannersByPositionAsync(BannerPosition position);
}
