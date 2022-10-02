using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shipping_Project.Repository.RolesRepo;
using Shipping_Project.ViewModel;

namespace Shipping_Project.Controllers
{

    //[Authorize(Roles = "SuperAdmin")]
    public class RolesController : Controller
    {
        private readonly IRoles roles;
        

        public RolesController(IRoles roles)
        {
            this.roles = roles;
        }
        public async Task<IActionResult> Index()
        {
            var role = await roles.GetAllRoles();
            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(RoleFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", await roles.GetAllRoles());
            }

            if (await roles.CheckRoleExistance(model))
            {
                ModelState.AddModelError("Name", "Role is exist!");
                return View("Index", await roles.GetAllRoles());
            }
            await roles.AddRole(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ManagePermissions(string roleId)
        {
            if (roles == null)
            {
                return NotFound();
            }
            var permissions = await roles.ManagePermission(roleId);
            return View(permissions);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManagePermissions(PermissionsFormViewModel model)
        {
            if (roles == null)
            {
                return NotFound();
            }
            await roles.UpdatePermission(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
