using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GamePortal.Infrastructure.Entities;

namespace GamePortal.Web.Pages;

[AllowAnonymous]
public class LoginModel : PageModel
{
    private readonly SignInManager<ApplicationUser> _signInManager;

    public LoginModel(SignInManager<ApplicationUser> signInManager)
    {
        _signInManager = signInManager;
    }

    [BindProperty]
    public string Email { get; set; } = string.Empty;

    [BindProperty]
    public string Password { get; set; } = string.Empty;

    [BindProperty]
    public bool RememberMe { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? ReturnUrl { get; set; }

    public string? ErrorMessage { get; set; }

    public void OnGet(string? returnUrl = null)
    {
        ReturnUrl = returnUrl;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
        {
            ErrorMessage = "Email and password are required.";
            return Page();
        }

        var result = await _signInManager.PasswordSignInAsync(
            Email, 
            Password, 
            RememberMe, 
            lockoutOnFailure: false);

        if (result.Succeeded)
        {
            // Redirect to admin or return URL
            var redirectUrl = ReturnUrl ?? "/admin";
            return Redirect(redirectUrl);
        }
        else if (result.IsLockedOut)
        {
            ErrorMessage = "This account is locked out. Please try again later.";
        }
        else if (result.RequiresTwoFactor)
        {
            ErrorMessage = "Two-factor authentication is required.";
        }
        else
        {
            ErrorMessage = "Invalid email or password. Please check your credentials and try again.";
        }

        return Page();
    }
}
