using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shipping_Project.Models;
using Shipping_Project.Repository.Product;
using Shipping_Project.Repository.UserRepo;
using Shipping_Project.ViewModel;

namespace Shipping_Project.Repository.Order
{
    
    public class Order:IOrder
    {
        private readonly ShippingDbContext Context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Order(ShippingDbContext db, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
                Context = db;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }


        private string GetCurrentUserId()
        {
            return _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
        }


        public List<Orders> GetAllOrdersForCurrentSeller()
        {
            string Id = GetCurrentUserId();
            List<Orders> AllOrders = Context.Orders.Where(o => o.User_Id == Id).Include(p=>p.Products).ToList();
            
            return AllOrders;
        }

        

        public  void Insert(OrderViewModel orderModel)
        {
            Orders order = new Orders();
            order.Type = orderModel.Type;
            order.CustomerName = orderModel.CustomerName;
            order.PhoneNumber = orderModel.PhoneNumber;
            order.Email = orderModel.Email;
            order.User_Id = GetCurrentUserId();
           

            Products product = new Products();
            
            product.ProductName = orderModel.ProductName;
            product.Quantity = orderModel.Quantity;
            product.ProductWight = orderModel.ProductWight;
            product.Wt_Id = 1;


            Weights weight = Context.Weights.FirstOrDefault(w => w.Id == 1);

            var normalWeight = weight.NormalWeight;
            var normalCost = weight.NormalCost;
            var extraCost = weight.ExtraCostPerKG;

            var orderWeight = Math.Abs(orderModel.Quantity * orderModel.ProductWight);

            
            if (orderWeight < normalWeight || orderWeight == normalWeight)
            {
                product.Cost = normalCost;
            }
            else if (orderWeight > normalWeight)
            {
                var additionalWeight = orderWeight - normalWeight;
                product.Cost = (normalCost) + (additionalWeight * extraCost);
            }
            

            Context.Products.Add(product);
            Context.SaveChanges();
            order.Pro_Id = product.Id;
            Context.Orders.Add(order);
            Context.SaveChanges();
        }

    }
}
