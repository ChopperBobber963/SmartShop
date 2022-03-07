using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SmartShop.Data.DataConstants;

namespace SmartShop.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        [MaxLength(ProductNameMaxLength)]
        public string Name { get; set; }

        [MaxLength(ProductDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        
        [Required]
        public string PictureURL { get; set; }

        public int ProductTypeId { get; set; }

        [ForeignKey(nameof(ProductTypeId))]
        public ProductType ProductType { get; set; }
    }
}
