using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping_Project.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        [Range(0.0, double.MaxValue, ErrorMessage = "Invalid Product Quantity")]

        public int Quantity { get; set; }

        [Range(0.0, double.MaxValue, ErrorMessage = "Invalid Product Weight")]
        public decimal ProductWight { get; set; }
        public decimal Cost { get; set; }


        [ForeignKey("Weights")]
        public int? Wt_Id { get; set; }
        public virtual Weights? Weights { get; set; }
        public virtual Orders? Orders { get; set; }
    }
}
