using GamePortal.Core.Entities;
using GamePortal.Core.Interfaces;
using GamePortal.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GamePortal.Infrastructure.Services;

public class SiteSettingsService : ISiteSettingsService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public SiteSettingsService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task<SiteSettings> GetSettingsAsync()
    {
        using var scope = _scopeFactory.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<ISiteSettingsRepository>();
        return await repository.GetOrCreateSettingsAsync();
    }

    public async Task<SiteSettings> UpdateSettingsAsync(SiteSettings settings)
    {
        using var scope = _scopeFactory.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<ISiteSettingsRepository>();
        var existing = await repository.GetSettingsAsync();
        
        if (existing == null)
        {
            settings.CreatedAt = DateTime.UtcNow;
            return await repository.AddAsync(settings);
        }
        
        existing.SiteName = settings.SiteName;
        existing.SiteDescription = settings.SiteDescription;
        existing.LogoUrl = settings.LogoUrl;
        existing.Email = settings.Email;
        existing.Phone = settings.Phone;
        existing.Address = settings.Address;
        existing.FacebookUrl = settings.FacebookUrl;
        existing.TwitterUrl = settings.TwitterUrl;
        existing.InstagramUrl = settings.InstagramUrl;
        existing.YoutubeUrl = settings.YoutubeUrl;
        existing.PrivacyPolicyUrl = settings.PrivacyPolicyUrl;
        existing.DisclaimerUrl = settings.DisclaimerUrl;
        existing.TermsOfServiceUrl = settings.TermsOfServiceUrl;
        existing.CopyrightText = settings.CopyrightText;
        existing.FooterDescription = settings.FooterDescription;
        existing.UpdatedAt = DateTime.UtcNow;
        
        repository.Update(existing);
        return existing;
    }
}

