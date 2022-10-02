using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Shipping_Project.Controllers
{
    //[Authorize(Roles = "SuperAdmin")]
    [Authorize(Roles = "SuperAdmin, Employee")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
