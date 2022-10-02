using System.ComponentModel.DataAnnotations;

namespace Shipping_Project.ViewModel
{
    public class RoleFormViewModel
    {
        [Required, StringLength(256)]
        public string Name { get; set; }
    }
}
