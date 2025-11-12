using GamePortal.Core.Entities;
using GamePortal.Core.Interfaces;
using GamePortal.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GamePortal.Infrastructure.Services;

public class BannerService : IBannerService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public BannerService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    private IBannerRepository CreateRepository(out IServiceScope scope)
    {
        scope = _scopeFactory.CreateScope();
        return scope.ServiceProvider.GetRequiredService<IBannerRepository>();
    }

    public async Task<IReadOnlyList<Banner>> GetAllAsync()
    {
        using var scope = _scopeFactory.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<IBannerRepository>();
        var banners = await repository.GetAllAsync();
        return banners.OrderBy(b => b.DisplayOrder).ToList();
    }

    public async Task<IReadOnlyList<Banner>> GetActiveByPositionAsync(BannerPosition position)
    {
        using var scope = _scopeFactory.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<IBannerRepository>();
        var banners = await repository.GetBannersByPositionAsync(position);
        return banners.OrderBy(b => b.DisplayOrder).ToList();
    }

    public async Task<Banner?> GetByIdAsync(int id)
    {
        using var scope = _scopeFactory.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<IBannerRepository>();
        return await repository.GetByIdAsync(id);
    }

    public async Task<Banner> CreateAsync(Banner banner)
    {
        using var scope = _scopeFactory.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<IBannerRepository>();
        banner.CreatedAt = DateTime.UtcNow;
        return await repository.AddAsync(banner);
    }

    public Task UpdateAsync(Banner banner)
    {
        using var scope = _scopeFactory.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<IBannerRepository>();
        banner.UpdatedAt = DateTime.UtcNow;
        repository.Update(banner);
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        using var scope = _scopeFactory.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<IBannerRepository>();
        await repository.DeleteAsync(id);
    }
}
