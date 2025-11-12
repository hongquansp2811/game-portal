using GamePortal.Core.Entities;
using GamePortal.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GamePortal.Infrastructure.Data;

public static class DbInitializer
{
	public static async Task Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
	{
		// Migration is handled in Startup.cs, so we don't need to run it here again
		// await context.Database.MigrateAsync();

		// Seed roles
		if (!await roleManager.Roles.AnyAsync())
		{
			await roleManager.CreateAsync(new IdentityRole("Admin"));
			await roleManager.CreateAsync(new IdentityRole("User"));
		}

		// Seed categories
		if (!await context.Categories.AnyAsync())
		{
			var categories = new List<Category>
			{
				new Category { Name = "Puzzle", Slug = "puzzle", IsActive = true, DisplayOrder = 1, CreatedAt = DateTime.UtcNow },
				new Category { Name = "Action", Slug = "action", IsActive = true, DisplayOrder = 2, CreatedAt = DateTime.UtcNow },
				new Category { Name = "Arcade", Slug = "arcade", IsActive = true, DisplayOrder = 3, CreatedAt = DateTime.UtcNow }
			};
			await context.Categories.AddRangeAsync(categories);
			await context.SaveChangesAsync();

			var puzzle = await context.Categories.FirstAsync(c => c.Slug == "puzzle");
			var action = await context.Categories.FirstAsync(c => c.Slug == "action");

			var games = new List<Game>
			{
				new Game
				{
					Title = "Ball Sort",
					Slug = "ball-sort",
					ThumbnailUrl = "https://cdn.ngxfiles.com/image/1736483618723_drop_ball.webp",
					Description = "A challenging puzzle game that will test your sorting skills",
					FullDescription = "Ball Sort is a challenging puzzle game that will test your sorting skills and strategic thinking.",
					GameUrl = "/games/ball-sort.html",
					CategoryId = puzzle.Id,
					Rating = 5,
					PlayCount = 3743,
					GameType = "Online",
					Platform = "Desktop, Tablet",
					IsHot = true,
					IsFeatured = true,
					CreatedAt = DateTime.UtcNow
				},
				new Game
				{
					Title = "Run Rush Puzzle",
					Slug = "run-rush-puzzle",
					ThumbnailUrl = "https://cdn.ngxfiles.com/image/1725445857694_fast_ball_puzzel.webp",
					Description = "Fast-paced puzzle solving adventure",
					FullDescription = "Run Rush Puzzle is a fast-paced puzzle game that challenges your problem-solving skills.",
					GameUrl = "/games/run-rush-puzzle.html",
					CategoryId = puzzle.Id,
					Rating = 4,
					PlayCount = 23423,
					GameType = "Online",
					Platform = "Desktop",
					IsHot = true,
					IsFeatured = true,
					CreatedAt = DateTime.UtcNow
				},
				new Game
				{
					Title = "Tricky Stick",
					Slug = "tricky-stick",
					ThumbnailUrl = "https://cdn.ngxfiles.com/image/1725446121048_trap_ball.webp",
					Description = "Test your precision and timing",
					FullDescription = "Tricky Stick is a precision game where you need to time your moves perfectly to hit the target.",
					GameUrl = "/games/tricky-stick.html",
					CategoryId = action.Id,
					Rating = 5,
					PlayCount = 9756,
					GameType = "Online",
					Platform = "Desktop, Mobile",
					IsHot = false,
					IsFeatured = true,
					CreatedAt = DateTime.UtcNow
				}
			};

			await context.Games.AddRangeAsync(games);
			await context.SaveChangesAsync();
		}

		// Update existing games with GameUrl if they don't have one
		var gamesWithoutUrl = await context.Games
			.Where(g => string.IsNullOrEmpty(g.GameUrl))
			.ToListAsync();

		foreach (var game in gamesWithoutUrl)
		{
			switch (game.Slug.ToLower())
			{
				case "ball-sort":
					game.GameUrl = "/games/ball-sort.html";
					break;
				case "run-rush-puzzle":
					game.GameUrl = "/games/run-rush-puzzle.html";
					break;
				case "tricky-stick":
					game.GameUrl = "/games/tricky-stick.html";
					break;
			}

			// Also add FullDescription if missing
			if (string.IsNullOrEmpty(game.FullDescription) && !string.IsNullOrEmpty(game.Description))
			{
				game.FullDescription = game.Description + " Play now and challenge yourself!";
			}
		}

		if (gamesWithoutUrl.Any())
		{
			await context.SaveChangesAsync();
		}

		// Seed banners
		if (!await context.Banners.AnyAsync())
		{
			var banners = new List<Banner>
			{
				new Banner
				{
					Title = "Happy New Year 2025",
					ImageUrl = "https://images.unsplash.com/photo-1511795409834-ef04bbd61622?w=1920&q=80",
					LinkUrl = null,
					Description = "Chúc mừng năm mới 2025 - Happy New Year!",
					Position = BannerPosition.Top,
					DisplayOrder = 1,
					IsActive = false, // Set to false for testing
					CreatedAt = DateTime.UtcNow
				}
			};
			await context.Banners.AddRangeAsync(banners);
			await context.SaveChangesAsync();
		}
		else
		{
			// Check if Happy New Year banner exists, if not add it
			var existingBanner = await context.Banners
				.FirstOrDefaultAsync(b => b.Title.Contains("Happy New Year"));
			
			if (existingBanner == null)
			{
				var newYearBanner = new Banner
				{
					Title = "Happy New Year 2025",
					ImageUrl = "https://images.unsplash.com/photo-1511795409834-ef04bbd61622?w=1920&q=80",
					LinkUrl = null,
					Description = "Chúc mừng năm mới 2025 - Happy New Year!",
					Position = BannerPosition.Top,
					DisplayOrder = 1,
					IsActive = false, // Set to false for testing
					CreatedAt = DateTime.UtcNow
				};
				await context.Banners.AddAsync(newYearBanner);
				await context.SaveChangesAsync();
			}
		}

		// Seed admin user - ensure it always exists
		var adminEmail = "admin@gameportal.com";
		var adminUser = await userManager.FindByEmailAsync(adminEmail);
		
		if (adminUser == null)
		{
			// Create new admin user
			adminUser = new ApplicationUser
			{
				UserName = adminEmail,
				Email = adminEmail,
				EmailConfirmed = true,
				FullName = "Administrator",
				CreatedAt = DateTime.UtcNow
			};
			var result = await userManager.CreateAsync(adminUser, "Admin123!");
			if (!result.Succeeded)
			{
				// Log errors if creation fails
				var errors = string.Join(", ", result.Errors.Select(e => e.Description));
				throw new Exception($"Failed to create admin user: {errors}");
			}
		}

		// Ensure admin user has Admin role
		if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
		{
			await userManager.AddToRoleAsync(adminUser, "Admin");
		}

		// Reset password to Admin123! if needed (for development)
		var passwordCheck = await userManager.CheckPasswordAsync(adminUser, "Admin123!");
		if (!passwordCheck)
		{
			var token = await userManager.GeneratePasswordResetTokenAsync(adminUser);
			await userManager.ResetPasswordAsync(adminUser, token, "Admin123!");
		}

		// Seed SiteSettings
		if (!await context.SiteSettings.AnyAsync())
		{
			var settings = new SiteSettings
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
			await context.SiteSettings.AddAsync(settings);
			await context.SaveChangesAsync();
		}
	}
}
