using GamePortal.Core.Entities;

namespace GamePortal.Core.Interfaces;

public interface ISiteSettingsRepository : IRepository<SiteSettings>
{
    Task<SiteSettings?> GetSettingsAsync();
    Task<SiteSettings> GetOrCreateSettingsAsync();
}

