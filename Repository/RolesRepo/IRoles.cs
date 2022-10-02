using Microsoft.AspNetCore.Identity;
using Shipping_Project.ViewModel;

namespace Shipping_Project.Repository.RolesRepo
{
    public interface IRoles
    {
        Task<List<IdentityRole>> GetAllRoles();
        Task AddRole(RoleFormViewModel model);
        Task<bool> CheckRoleExistance(RoleFormViewModel model);
        Task<PermissionsFormViewModel> ManagePermission(string roleId);
        Task UpdatePermission(PermissionsFormViewModel model);
    }
}
