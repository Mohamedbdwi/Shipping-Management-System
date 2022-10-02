using Microsoft.AspNetCore.Mvc;
using Shipping_Project.ViewModel;

namespace Shipping_Project.Repository.UserRepo
{
    public interface IUser
    {
        List<UserViewModel> GetAllUsers();
        Task<UserRolesViewModel> ManageRole(string userId);
        Task UpdateRole(UserRolesViewModel model);
    }
}
