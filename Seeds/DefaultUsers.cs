using Microsoft.AspNetCore.Identity;
using Shipping_Project.Constants;
using System.Security.Claims;

namespace Shipping_Project.Seeds
{
    public static class DefaultUsers
    {

        //public static async Task seedBasicUserAsync(UserManager<IdentityUser> userManager)
        //{
        //    var defaultUser = new IdentityUser
        //    {
        //        UserName = "basic@domain.com",
        //        Email = "basic@domain.com",
        //        EmailConfirmed = true
        //    };

        //    //var user = await userManager.FindByEmailAsync(defaultUser.Email);

        //    //if (user == null)
        //    //{
        //        await userManager.CreateAsync(defaultUser, "P@ssword123");

        //        await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
        //    //}
        //}

        public static async Task seedSuperAdminUserAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new IdentityUser
            {
                UserName = "superadmin@domain.com",
                Email = "superadmin@domain.com",
                EmailConfirmed = true
            };

            //var user = await userManager.FindByEmailAsync(defaultUser.Email);

            //if (user == null)
            //{
                await userManager.CreateAsync(defaultUser, "P@ssword456");

            await userManager.AddToRolesAsync(defaultUser, new List<string> { Roles.Employee.ToString(), Roles.Seller.ToString(), Roles.SuperAdmin.ToString() });
            //}
            await roleManager.SeedClaimsForSuperAdmin();

        }

        private static async Task SeedClaimsForSuperAdmin(this RoleManager<IdentityRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync(Roles.SuperAdmin.ToString());
            
            await roleManager.AddPermissionClaims(adminRole, "Employees");
            await roleManager.AddPermissionClaims(adminRole, "GeneralSettings");
            await roleManager.AddPermissionClaims(adminRole, "AttendenceAndLeave");
            await roleManager.AddPermissionClaims(adminRole, "SalaryReport");
        }

        public static async Task AddPermissionClaims(this RoleManager<IdentityRole> roleManager, IdentityRole role, string module)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = Permissions.GeneratePermissionList(module);
            foreach(var Permission in allPermissions)
            {
                if(!allClaims.Any(c=>c.Type== "Permission" && c.Value == Permission))
                {
                    await roleManager.AddClaimAsync(role, new Claim("Permission", Permission));
                }
            }
        }
    }
}
