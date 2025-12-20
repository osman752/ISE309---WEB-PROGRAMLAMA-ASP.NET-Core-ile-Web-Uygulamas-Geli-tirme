using Microsoft.AspNetCore.Identity;
using OnlineKursKayit.Models;

namespace OnlineKursKayit.Data
{
    public static class SeedData
    {
        private static readonly string[] Roles = new[] { "Admin", "Instructor", "Student" };

        public static async Task EnsureSeedAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            foreach (var role in Roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // Default Admin
            var adminEmail = "admin@course.local";
            var adminPassword = "Admin123*";

            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var createRes = await userManager.CreateAsync(adminUser, adminPassword);
                if (!createRes.Succeeded) return;
            }

            if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
                await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}
