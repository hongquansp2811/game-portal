using GamePortal.Infrastructure.Entities;
using GamePortal.Core.Interfaces;
using GamePortal.Core.Services;
using GamePortal.Infrastructure.Data;
using GamePortal.Infrastructure.Mappings;
using GamePortal.Infrastructure.Repositories;
using GamePortal.Infrastructure.Services;
using GamePortal.Web.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace GamePortal.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Database - Support both SQL Server (local) and PostgreSQL (production)
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                if (string.IsNullOrEmpty(connectionString))
                {
                    // Fallback to in-memory for testing
                    options.UseInMemoryDatabase("GamePortalDb");
                }
                else if (connectionString.Contains("Server=") || connectionString.Contains("Data Source="))
                {
                    // SQL Server
                    options.UseSqlServer(
                        connectionString,
                        b => b.MigrationsAssembly("GamePortal.Infrastructure"));
                }
                else
                {
                    // PostgreSQL (Railway, Render, etc.)
                    options.UseNpgsql(
                        connectionString,
                        b => b.MigrationsAssembly("GamePortal.Infrastructure"));
                }
            });

            // Identity
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            // AutoMapper
            services.AddAutoMapper(typeof(MappingProfile));

            // Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBannerRepository, BannerRepository>();
            services.AddScoped<ISiteSettingsRepository, SiteSettingsRepository>();

            // Services
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IBannerService, BannerService>();
            services.AddScoped<ISiteSettingsService, SiteSettingsService>();

            // Health Checks
            services.AddHealthChecks();

            // Blazor
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();

            // Authorization
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdmin", policy => policy.RequireRole("Admin"));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // Health Check endpoint (must be before other endpoints)
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health");
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            // Run migrations and seed database on startup (non-blocking, run in background)
            _ = Task.Run(async () =>
            {
                try
                {
                    await Task.Delay(5000); // Wait 5 seconds for app to start
                    using (var scope = app.ApplicationServices.CreateScope())
                    {
                        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                        
                        // Run migrations automatically
                        try
                        {
                            await context.Database.MigrateAsync();
                            Console.WriteLine("Database migrations applied successfully.");
                        }
                        catch (Exception migEx)
                        {
                            Console.WriteLine($"Migration error (may be normal if already applied): {migEx.Message}");
                        }
                        
                        // Seed database
                        await DbInitializer.Initialize(context, userManager, roleManager);
                    }
                }
                catch (Exception ex)
                {
                    // Log error but don't crash the app
                    Console.WriteLine($"Database initialization error: {ex.Message}");
                }
            });
        }
    }
}
