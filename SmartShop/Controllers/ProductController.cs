using Microsoft.AspNetCore.Mvc;
using SmartShop.Data;
using SmartShop.Models.Product;

namespace SmartShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly SmartShopDbContext dbContext;

        public ProductController(SmartShopDbContext data)
        {
            dbContext = data;
        }

        public IActionResult Add()
            => View(new AddProductForm
            {
               ProductTypes = GetProductTypes()
            });


        [HttpPost]
        public IActionResult Add(AddProductForm product)
        {
            return View();
        }

        private IEnumerable<ProductTypeViewModel> GetProductTypes()
         =>
                dbContext.ProductTypes
                .Select(pt => new ProductTypeViewModel
                {
                    Id = pt.Id,
                    Name = pt.Name
                })
                .ToList();
        
    }
}
