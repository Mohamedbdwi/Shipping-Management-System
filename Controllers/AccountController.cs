using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shipping_Project.Models;
using Shipping_Project.Repository.Account;
using Shipping_Project.ViewModel;

namespace Shipping_Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccount account;

        public AccountController(IAccount account)
        {
            this.account = account;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel newUserVM)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await account.SellerRegisteration(newUserVM);
                if (result.Succeeded)
                {
                    account.AddRegisterCookie(newUserVM);
                    return RedirectToAction("Index", "Seller");
                }
                else
                {
                    foreach (var errorItem in result.Errors)
                    {
                        ModelState.AddModelError("Password", errorItem.Description);
                    }
                }
            }
            return View(newUserVM);
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult AddNewUser()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> AddNewUser(RegisterUserViewModel newUserVM)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await account.EmployeeRegisteration(newUserVM);
                if (result.Succeeded)
                {
                    account.AddRegisterCookie(newUserVM);
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    foreach (var errorItem in result.Errors)
                    {
                        ModelState.AddModelError("Password", errorItem.Description);
                    }
                }
            }
            return View(newUserVM);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                var found = await account.CheckLoginData(userVM);
                if(found == true)
                {
                    await account.AddLoginCookie(userVM);
                    var checkRole = await account.CheckRole(userVM);
                    if (checkRole)
                    {
                        return RedirectToAction("Index", "Seller");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Dashboard");
                    }
                }
                ModelState.AddModelError("", "Invalid User name or Password");
                
            }
            return View(userVM);
        }


        public IActionResult Logout()
        {
            account.Logout();
            return RedirectToAction("Login");
        }

    }
}
