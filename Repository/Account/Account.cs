using MessagePack.Formatters;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Shipping_Project.Constants;
using Shipping_Project.Models;
using Shipping_Project.Seeds;
using Shipping_Project.ViewModel;

namespace Shipping_Project.Repository.Account
{
    public class Account : IAccount
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public Account(UserManager<ApplicationUser> userManager,
                    RoleManager<IdentityRole> roleManager,
                    SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public ApplicationUser MappingRegisterViewModel(RegisterUserViewModel newUserVM)
        {
            ApplicationUser userModel = new ApplicationUser();
            userModel.UserName = newUserVM.UserName;
            userModel.PasswordHash = newUserVM.Password;
            return userModel;
        }
        public async Task<IdentityResult> SellerRegisteration(RegisterUserViewModel newUserVM)
        {
            ApplicationUser userModel = MappingRegisterViewModel(newUserVM);
            var result = await _userManager.CreateAsync(userModel, newUserVM.Password);
            await _userManager.AddToRoleAsync(userModel, Roles.Seller.ToString());
            return result;
        }

        public async Task<IdentityResult> EmployeeRegisteration(RegisterUserViewModel newUserVM)
        {
            ApplicationUser userModel = MappingRegisterViewModel(newUserVM);
            var result = await _userManager.CreateAsync(userModel, newUserVM.Password);
            await _userManager.AddToRoleAsync(userModel, Roles.Employee.ToString());
            return result;
        }

        public async Task AddRegisterCookie(RegisterUserViewModel newUserVM)
        {
            ApplicationUser userModel = MappingRegisterViewModel(newUserVM);
            await _signInManager.SignInAsync(userModel, false);
        }
        public async Task<ApplicationUser> GetLoginRefrence(LoginUserViewModel userVM)
        {
            return await _userManager.FindByNameAsync(userVM.UserName);
        }

        public async Task<bool> CheckLoginData(LoginUserViewModel userVM)
        {
            ApplicationUser userModel = await GetLoginRefrence(userVM);
            if (userModel == null)
            {
                return false;
                
            }
            bool found = await _userManager.CheckPasswordAsync(userModel, userVM.Password);

            return found;
        }

        public async Task AddLoginCookie(LoginUserViewModel userVM)
        {
            ApplicationUser userModel = await GetLoginRefrence(userVM);
            await _signInManager.SignInAsync(userModel, userVM.RememberMe);
        }

        public async Task<bool> CheckRole(LoginUserViewModel userVM)
        {
            ApplicationUser userModel = await _userManager.FindByNameAsync(userVM.UserName);
            var checkeded = await _userManager.IsInRoleAsync(userModel, Roles.Seller.ToString());
            return checkeded;

        }


        public void Logout()
        {
            _signInManager.SignOutAsync();
          
        }

        

        
    }
}
