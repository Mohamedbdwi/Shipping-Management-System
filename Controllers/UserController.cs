using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shipping_Project.Constants;
using Shipping_Project.Repository.UserRepo;
using Shipping_Project.ViewModel;

namespace Shipping_Project.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class UserController : Controller
    {
        private readonly IUser user;
        public UserController(IUser user)
        {
            this.user = user;
        }

        public async Task<IActionResult> Index()
        {
            var users =  user.GetAllUsers();
            return View(users);
        }

        public async Task<IActionResult> ManageRoles(string userId)
        {
            if (user == null)
                return NotFound();
            var roles =await user.ManageRole(userId);
            return View(roles);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRoles(UserRolesViewModel model)
        {
            if (user == null)
                return NotFound();
            await user.UpdateRole(model);
            return RedirectToAction(nameof(Index));
        }


    }
}
