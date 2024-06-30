using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestAssured.Models;

namespace RestAssured.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            builder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Mahogony Dining Table", Description = "It's beautiful", Price = 799 },
                new Product { Id = 1, Name = "Oak Chair Set of 6", Description = "It's beautiful", Price = 499 },
                new Product { Id = 1, Name = "Plum Poof w/Cushion", Description = "It's beautiful", Price = 250 },
                new Product { Id = 1, Name = "Walnut Wardrobe", Description = "It's beautiful", Price = 900 }
                );

            base.OnModelCreating(builder);
        }
    }
}
