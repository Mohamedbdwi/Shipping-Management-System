using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shipping_Project.Models;
using Shipping_Project.Repository.Order;
using Shipping_Project.ViewModel;

namespace Shipping_Project.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrder order;

        public OrderController(IOrder order)
        {
            this.order = order;
        }

        [Authorize(Roles = "Seller")]
        public IActionResult Index()
        {
            List<Orders> AllOrders = order.GetAllOrdersForCurrentSeller();
            return View(AllOrders);
        }


        [HttpGet]
        [Authorize(Roles = "Seller")]
        public IActionResult NewOrder()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Seller")]
        public IActionResult NewOrder(OrderViewModel orderModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Check your data");
                
                //return View(orderModel);
            }
            order.Insert(orderModel);
            return RedirectToAction("Index", "Order");
        }

        
    }
}
