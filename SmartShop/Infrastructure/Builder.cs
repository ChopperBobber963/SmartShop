using SmartShop.Data;
using SmartShop.Data.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace SmartShop.Infrastructure
{
    public static class Builder
    {
       public static WebApplication PrepDb(this WebApplication app)
       {
            using var scopedServices = app.Services.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<SmartShopDbContext>();

            data.Database.Migrate();

            SeedCategories(data);

            return app;
       }
        
        private static void SeedCategories(SmartShopDbContext data)
        {
            if (data.ProductTypes.Any())
            {
                return;
            }

            data.ProductTypes.AddRange(new[]
            {
                new ProductType{Name = "Video Games"},
                new ProductType{Name = "Books"},
                new ProductType{Name = "Smartphones"},
                new ProductType{Name = "Laptops"},
                new ProductType{Name = "Headphones"},
                new ProductType{Name = "TVs"},
                new ProductType{Name = "Movies and TV"},
                new ProductType{Name = "Music"}
            });
            data.SaveChanges();
        }
    }
}
