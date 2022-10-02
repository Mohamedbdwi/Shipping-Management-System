using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shipping_Project.Models;
using Shipping_Project.ViewModel;

namespace Shipping_Project.Repository.UserRepo
{
    public class User : IUser
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public User(UserManager<ApplicationUser> userManager,
                    RoleManager<IdentityRole> roleManager,
                    SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }



        public List<UserViewModel> GetAllUsers()
        {
            var users = _userManager.Users
                .Select(user => new UserViewModel {
                    Id = user.Id, UserName = user.UserName, Email = user.Email,
                    Roles = _userManager.GetRolesAsync(user).Result })
                .ToList();
            return users;
        }

        public async Task<UserRolesViewModel> ManageRole(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            var roles = await _roleManager.Roles.ToListAsync();
            var viewModel = new UserRolesViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Roles = roles.Select(role => new CheckBoxViewModel
                {
                    DisplayValue = role.Name,
                    IsSelected = _userManager.IsInRoleAsync(user, role.Name).Result
                }).ToList()
            };
            return viewModel;
        }

        public async Task UpdateRole(UserRolesViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
             
            var userRoles = await _userManager.GetRolesAsync(user);

            await _userManager.RemoveFromRolesAsync(user, userRoles);
            await _userManager.AddToRolesAsync(user, 
                model.Roles.Where(r =>r.IsSelected)
                .Select(r => r.DisplayValue));
        }
    }
}
