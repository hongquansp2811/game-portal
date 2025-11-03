using GamePortal.Core.Entities;
using GamePortal.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GamePortal.Infrastructure.Data;

public static class DbInitializer
{
	public static async Task Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
	{
		await context.Database.MigrateAsync();

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

		// Seed admin user
		if (!await context.Users.AnyAsync())
		{
			var admin = new ApplicationUser
			{
				UserName = "admin@gameportal.com",
				Email = "admin@gameportal.com",
				EmailConfirmed = true,
				FullName = "Administrator",
				CreatedAt = DateTime.UtcNow
			};
			var result = await userManager.CreateAsync(admin, "Admin123!");
			if (result.Succeeded)
			{
				await userManager.AddToRoleAsync(admin, "Admin");
			}
		}
	}
}
