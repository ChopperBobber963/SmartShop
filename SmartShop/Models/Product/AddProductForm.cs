using SmartShop.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace SmartShop.Models.Product
{
    public class AddProductForm
    {
        
        public string Name { get; set; }

        
        public string Description { get; set; }

        
        public double Price { get; set; }

        [Display(Name = "Image URL")]        
        public string PictureURL { get; set; }

        [Display(Name = "Product Type")]
        public int ProductTypeId { get; set; }

        public IEnumerable<ProductTypeViewModel> ProductTypes { get; set; }
    }
}
