using System.ComponentModel.DataAnnotations;

namespace SmartShop.Models.Product
{
    using static Data.DataConstants;
    public class EditProductForm
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ProductNameMaxLength, MinimumLength = ProductNameMinLength,
           ErrorMessage = "{0} must be between {2} and {1} characters long")]
        public string Name { get; set; }

        [Required]
        [StringLength(ProductDescriptionMaxLength, MinimumLength = ProductDescriptionMinLength,
            ErrorMessage = "{0} must be between {2} and {1} characters long")]
        public string Description { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "{0} is required and cannot be null")]
        public double Price { get; set; }

        [Url]
        [Required]
        [Display(Name = "Image URL")]
        public string PictureURL { get; set; }

        [Display(Name = "Product Type")]
        public int ProductTypeId { get; set; }

        public IEnumerable<ProductTypeViewModel> ProductTypes { get; set; } = new List<ProductTypeViewModel>();
    }
}
