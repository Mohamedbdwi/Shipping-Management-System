using Microsoft.AspNetCore.Mvc;

namespace Shipping_Project.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
