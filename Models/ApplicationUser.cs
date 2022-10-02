using Microsoft.AspNetCore.Identity;

namespace Shipping_Project.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? fullName { get; set; }
        public virtual List<Orders>? Orders { get; set; }
    }
}
