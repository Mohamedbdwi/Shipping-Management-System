using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shipping_Project.Models;
using Shipping_Project.Repository.Account;
using Shipping_Project.Repository.Order;
using Shipping_Project.Repository.RolesRepo;
using Shipping_Project.Repository.UserRepo;
using Shipping_Project.Repository.Weight;

namespace Shipping_Project
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Configuration DbContext
            builder.Services.AddDbContext<ShippingDbContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("ShippingDB")));
            

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
                options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ShippingDbContext>();

            builder.Services.AddScoped<IUser, User>();
            builder.Services.AddScoped<IRoles, Roles>();
            builder.Services.AddScoped<IAccount, Account>();
            builder.Services.AddScoped<IWeight, Weight>();
            builder.Services.AddScoped<IOrder, Order>();


            var app = builder.Build();

            using var scope = app.Services.CreateScope();
                  var services = scope.ServiceProvider;
                  var loggerFactory = services.GetRequiredService<ILoggerProvider>();
                  var logger = loggerFactory.CreateLogger("app");

            try
            {
                var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                await Seeds.DefaultRoles.SeedAsync(roleManager);
                //await Seeds.DefaultUsers.seedBasicUserAsync(userManager);
                await Seeds.DefaultUsers.seedSuperAdminUserAsync(userManager, roleManager);

                logger.LogInformation("Data Seeded");
                logger.LogInformation("Application Started");
            }
            catch (System.Exception ex)
            {
                logger.LogWarning(ex, "An error occured while seeding data");
            }




            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();


            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}