using Microsoft.AspNetCore.Identity;

namespace GamePortal.Infrastructure.Entities;

public class ApplicationUser : IdentityUser
{
    public string? FullName { get; set; }
    public string? AvatarUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastLoginAt { get; set; }
}

