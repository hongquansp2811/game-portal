using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using GamePortal.Infrastructure.Entities;

namespace GamePortal.Web.Infrastructure;

public class RevalidatingIdentityAuthenticationStateProvider<TUser> : ServerAuthenticationStateProvider
    where TUser : class
{
    private readonly IServiceScopeFactory _scopeFactory;

    public RevalidatingIdentityAuthenticationStateProvider(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        // Blazor Server uses HttpContext.User automatically via base class
        return base.GetAuthenticationStateAsync();
    }
}
