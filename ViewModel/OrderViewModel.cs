namespace Shipping_Project.ViewModel
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string CustomerName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal ProductWight { get; set; }
        public decimal Cost { get; set; }
    }
}
