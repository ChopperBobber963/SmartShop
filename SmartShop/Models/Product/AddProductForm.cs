
namespace SmartShop.Models.Product
{
    using SmartShop.Data.Models;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;
    public class AddProductForm
    {
        [Required]
        [StringLength(ProductNameMaxLength, MinimumLength = ProductNameMinLength,
            ErrorMessage = "{0} must be between {2} and {1} characters long")]
        public string Name { get; set; }

        [Required]
        [StringLength(ProductDescriptionMaxLength, MinimumLength = ProductDescriptionMinLength,
            ErrorMessage = "{0} must be between {2} and {1} characters long")]
        public string Description { get; set; }

        [Required]
        [Range(0, double.MaxValue,ErrorMessage = "{0} must be between {1} and {2}")]
        public double Price { get; set; }

        [Url]
        [Required]
        [Display(Name = "Image URL")]        
        public string PictureURL { get; set; }

        [Display(Name = "Product Type")]
        public int ProductTypeId { get; set; }

        public IEnumerable<ProductTypeViewModel> ProductTypes { get; set; }
    }
}
