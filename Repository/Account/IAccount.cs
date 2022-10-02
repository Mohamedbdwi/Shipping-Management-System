using Microsoft.AspNetCore.Identity;
using Shipping_Project.Models;
using Shipping_Project.ViewModel;

namespace Shipping_Project.Repository.Account
{
    public interface IAccount
    {
        ApplicationUser MappingRegisterViewModel(RegisterUserViewModel newUserVM);
        Task<IdentityResult> SellerRegisteration(RegisterUserViewModel newUserVM);
        Task<IdentityResult> EmployeeRegisteration(RegisterUserViewModel newUserVM);
        Task AddRegisterCookie(RegisterUserViewModel newUserVM);
        Task<ApplicationUser> GetLoginRefrence(LoginUserViewModel userVM);
        Task<bool> CheckLoginData(LoginUserViewModel userVM);
        Task AddLoginCookie(LoginUserViewModel userVM);
        Task<bool> CheckRole(LoginUserViewModel userVM);
        void Logout();
    }
}
