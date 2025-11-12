using GamePortal.Core.Entities;
using GamePortal.Core.Interfaces;
using GamePortal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GamePortal.Infrastructure.Repositories;

public class SiteSettingsRepository : Repository<SiteSettings>, ISiteSettingsRepository
{
    public SiteSettingsRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<SiteSettings?> GetSettingsAsync()
    {
        return await _dbSet
            .OrderByDescending(s => s.Id)
            .FirstOrDefaultAsync();
    }

    public async Task<SiteSettings> GetOrCreateSettingsAsync()
    {
        var settings = await GetSettingsAsync();
        if (settings == null)
        {
            settings = new SiteSettings
            {
                SiteName = "GamePortal",
                SiteDescription = "Your webgame management system - Discover and play the best games online",
                FooterDescription = "Embrace the best in gaming at GamePortal! Each day, our team reviews and selects top-notch games, providing you with unbiased insights and a premier experience for iOS and Android enthusiasts.",
                Email = "contact@gameportal.com",
                Phone = "+84 123 456 789",
                Address = "123 Gaming Street, Ho Chi Minh City, Vietnam",
                FacebookUrl = "https://facebook.com/gameportal",
                TwitterUrl = "https://twitter.com/gameportal",
                InstagramUrl = "https://instagram.com/gameportal",
                YoutubeUrl = "https://youtube.com/gameportal",
                PrivacyPolicyUrl = "/privacy-policy",
                DisclaimerUrl = "/disclaimer",
                TermsOfServiceUrl = "/terms-of-service",
                CopyrightText = $"© {DateTime.Now.Year} GamePortal. All rights reserved.",
                CreatedAt = DateTime.UtcNow
            };
            await _dbSet.AddAsync(settings);
            await _context.SaveChangesAsync();
        }
        return settings;
    }
}

