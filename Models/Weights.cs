namespace Shipping_Project.Models
{
    public class Weights
    {
        public int Id { get; set; }
        public decimal NormalWeight { get; set; } 
        public decimal NormalCost { get; set; } 
        public decimal ExtraCostPerKG { get; set; } 
        public virtual List<Products>? Product { get; set; }
    }
}
