using LaBook_Planet.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.Services.TestManagement.TestPlanning.WebApi;
using System;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public static class UserRoleInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

            string[] roleNames = { "Admin", "Editor", "User" };

            IdentityResult outCome;

            foreach (var role in roleNames)
            {
                var existingRole = await roleManager.RoleExistsAsync(role);

                if (!existingRole)
                {
                    outCome = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var email = "bentleyjochebed@gmail.com";
            var password = "BentleyJochebed23@gmail.com";

            if (userManager.FindByEmailAsync(email).Result == null)
            {
                AppUser user = new()
                {
                    Email = email,
                    UserName = email,
                    FirstName = "Jochebed",
                    LastName = "Bentley",
                };

                IdentityResult result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

        }
    }
}
