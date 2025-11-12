using GamePortal.Core.Entities;

namespace GamePortal.Core.Services;

public interface ISiteSettingsService
{
    Task<SiteSettings> GetSettingsAsync();
    Task<SiteSettings> UpdateSettingsAsync(SiteSettings settings);
}

