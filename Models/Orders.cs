using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping_Project.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string CustomerName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }



        [ForeignKey("ApplicationUser")]
        public string? User_Id { get; set; }

        [ForeignKey("Products")]
        public int? Pro_Id { get; set; }

        public virtual ApplicationUser? ApplicationUser { get; set; }
        public virtual Products? Products { get; set; }

    }
}
