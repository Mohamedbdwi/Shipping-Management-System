using Microsoft.AspNetCore.Identity;
using Shipping_Project.Constants;

namespace Shipping_Project.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Roles.Employee.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Roles.Seller.ToString()));
            }
        }
    }
}
