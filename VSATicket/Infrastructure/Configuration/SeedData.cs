using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using VSATicket.Domain.Common.Models;

namespace VSATicket.Infrastructure.Data
{
    public static class SeedData
    {
        public static async Task SeedRolesAndUsers(this IHost app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                var roles = new[] { "admin", "user" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }

                var adminUser = new AppUser
                {
                    UserName = "adminUser",
                    Email = "admin@example.com"
                };
                if (userManager.Users.All(u => u.UserName != adminUser.UserName))
                {
                    var result = await userManager.CreateAsync(adminUser, "AdminPassword123!");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(adminUser, "admin");
                    }
                }

                var basicUser = new AppUser
                {
                    UserName = "basicUser",
                    Email = "user@example.com"
                };
                if (userManager.Users.All(u => u.UserName != basicUser.UserName))
                {
                    var result = await userManager.CreateAsync(basicUser, "UserPassword123!");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(basicUser, "user");
                    }
                }
            }
        }
    }
}
