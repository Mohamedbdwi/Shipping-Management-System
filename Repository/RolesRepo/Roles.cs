using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shipping_Project.Constants;
using Shipping_Project.ViewModel;
using System.Security.Claims;

namespace Shipping_Project.Repository.RolesRepo
{
    public class Roles:IRoles
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public Roles(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<IdentityRole>> GetAllRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return roles;
        }
        
        public async Task<bool> CheckRoleExistance(RoleFormViewModel model)
        {
            var rolesExist = await _roleManager.RoleExistsAsync(model.Name);
            return rolesExist;
        }

        public async Task AddRole(RoleFormViewModel model)
        {
            await _roleManager.CreateAsync(new IdentityRole(model.Name.Trim()));
        }

        public async Task<PermissionsFormViewModel> ManagePermission(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            var roleClaims = _roleManager.GetClaimsAsync(role).Result
                .Select(c => c.Value).ToList();

            var allClaims = Permissions.GenerateAllPermissions();
            var allPermissions = allClaims.Select(p => new CheckBoxViewModel
            {
                DisplayValue = p
            }).ToList();

            foreach(var permission in allPermissions)
            {
                if (roleClaims.Any(c => c == permission.DisplayValue))
                {
                    permission.IsSelected = true;
                }
            }

            var viewModel = new PermissionsFormViewModel
            {
                RoleId = role.Id,
                RoleName = role.Name,
                RoleClaims = allPermissions
            };

            return viewModel;
        }

        public async Task UpdatePermission(PermissionsFormViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);
            var roleClaims =await _roleManager.GetClaimsAsync(role);

            foreach (var claim in roleClaims)
                await _roleManager.RemoveClaimAsync(role, claim);

            var selectedClaims = model.RoleClaims.Where(c => c.IsSelected).ToList();
            foreach (var claim in selectedClaims)
                await _roleManager.AddClaimAsync(role, new Claim("Permission", claim.DisplayValue));

        }
    }
}
