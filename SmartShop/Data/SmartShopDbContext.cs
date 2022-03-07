using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartShop.Data.Models;

namespace SmartShop.Data
{
    public class SmartShopDbContext : IdentityDbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        public SmartShopDbContext(DbContextOptions<SmartShopDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .HasOne(p => p.ProductType)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.ProductTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder); 
        }
    }
}