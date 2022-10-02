using Shipping_Project.Models;
using Shipping_Project.ViewModel;

namespace Shipping_Project.Repository.Order
{
    public interface IOrder
    {
        List<Orders> GetAllOrdersForCurrentSeller();
        void Insert(OrderViewModel orderModel);

        
    }
}
