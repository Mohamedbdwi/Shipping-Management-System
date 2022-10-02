using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Shipping_Project.Controllers
{
    public class SellerController : Controller
    {
        [Authorize(Roles = "Seller")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
