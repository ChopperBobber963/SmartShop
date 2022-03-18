using Microsoft.AspNetCore.Mvc;
using SmartShop.Data;
using SmartShop.Data.Models;
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
            if (!this.dbContext.ProductTypes.Any(pt => pt.Id == product.ProductTypeId))
            {
                ModelState.AddModelError(nameof(product.ProductTypeId), "Product Type is nonexistent");
            }

            if (!ModelState.IsValid)
            {
                product.ProductTypes = GetProductTypes();
                return View(product);
            }

            var productData = new Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                PictureURL = product.PictureURL,
                ProductTypeId = product.ProductTypeId
            };

            dbContext.Products.Add(productData); 
            dbContext.SaveChanges();


            return RedirectToAction(nameof(AllProducts));
        }

        public IActionResult AllProducts(string search)
        {
            var productsQuery = dbContext.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                productsQuery = productsQuery.Where(p =>
                p.Name.ToLower().Contains(search.ToLower()));
            }

           

            var products = productsQuery
                .OrderByDescending(pt => pt.Id)
                .Select(p => new ProductListingViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description= p.Description,
                    Price = p.Price,
                    PictureURL = p.PictureURL,
                    ProductType = p.ProductType.Name
                })
                .ToList();

            return View(new AllProductsViewModel
            {
                Products = products,
                Search = search
            });
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
