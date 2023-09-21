
using LaBook_Planet.Data.Entities;
using LaBook_Planet.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace LaBook_Planet.Library.Core.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> RegisterAsync(AppUser user, string password);

        Task<bool> LoginAsync(AppUser user, string password);

        bool IsLoggedInAsync(ClaimsPrincipal user);

        Task LogoutAsync();
    }
}
