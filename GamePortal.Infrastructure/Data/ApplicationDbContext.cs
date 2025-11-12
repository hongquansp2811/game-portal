using GamePortal.Core.Entities;
using GamePortal.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GamePortal.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<GameGallery> GameGalleries { get; set; }
    public DbSet<GameReview> GameReviews { get; set; }
    public DbSet<Banner> Banners { get; set; }
    public DbSet<TipGuide> TipGuides { get; set; }
    public DbSet<TipGuideCategory> TipGuideCategories { get; set; }
    public DbSet<SiteSettings> SiteSettings { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Configure entities
        builder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Slug).IsRequired().HasMaxLength(200);
            entity.HasIndex(e => e.Slug).IsUnique();
        });

        builder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Slug).IsRequired().HasMaxLength(200);
            entity.HasIndex(e => e.Slug).IsUnique();
            entity.HasOne(e => e.Category)
                .WithMany(c => c.Games)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<GameGallery>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Game)
                .WithMany(g => g.Galleries)
                .HasForeignKey(e => e.GameId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<GameReview>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Game)
                .WithMany(g => g.Reviews)
                .HasForeignKey(e => e.GameId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<Banner>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        builder.Entity<SiteSettings>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.SiteName).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        builder.Entity<TipGuide>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Slug).IsRequired().HasMaxLength(200);
            entity.HasIndex(e => e.Slug).IsUnique();
        });

        builder.Entity<TipGuideCategory>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.TipGuide)
                .WithMany(t => t.Categories)
                .HasForeignKey(e => e.TipGuideId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.Category)
                .WithMany()
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Configure Identity
        builder.Entity<ApplicationUser>(entity =>
        {
            entity.Property(e => e.FullName).HasMaxLength(200);
            entity.Property(e => e.AvatarUrl).HasMaxLength(500);
        });

        // Global filter for soft delete
        builder.Entity<Category>().HasQueryFilter(e => !e.IsDeleted);
        builder.Entity<Game>().HasQueryFilter(e => !e.IsDeleted);
        builder.Entity<Banner>().HasQueryFilter(e => !e.IsDeleted);
        builder.Entity<TipGuide>().HasQueryFilter(e => !e.IsDeleted);
        // SiteSettings không dùng soft delete vì chỉ có 1 record
    }
}

