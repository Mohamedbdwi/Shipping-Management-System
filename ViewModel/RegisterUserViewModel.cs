using System.ComponentModel.DataAnnotations;

namespace Shipping_Project.ViewModel
{
    public class RegisterUserViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ComfirmPassword { get; set; }
    }
}
