using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Emit;

namespace Shipping_Project.Models
{
    public class ShippingDbContext : IdentityDbContext<ApplicationUser>
    {
        //Configuration DbContext
        private readonly IConfiguration configuration;

        public ShippingDbContext()
        {

        }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Weights> Weights { get; set; }

        public ShippingDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Database=ShippingSystem;Integrated Security=True;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Weights>()
                .HasData(new Weights
                {
                    Id = 1,
                    NormalWeight = 10,
                    NormalCost = 5,
                    ExtraCostPerKG = 5
                });

        }

    }
}
