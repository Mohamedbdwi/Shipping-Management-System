using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Shipping_Project.Constants
{
    public static class Permissions
    {
        public static List<string> GeneratePermissionList(string module)
        {
            return new List<string>() {
            $"Permission.{module}.View",
            $"Permission.{module}.Create",
            $"Permission.{module}.Edit",
            $"Permission.{module}.Delete"
            };
        }

        public static List<string> GenerateAllPermissions()
        {
            var allPermissions = new List<string>();
            var modules = Enum.GetValues(typeof(Modules));
            foreach(var module in modules)
            {
                allPermissions.AddRange(GeneratePermissionList(module.ToString()));
            }
            return allPermissions;
        }
    }
}
