namespace SmartShop.Models.Product
{
    public class ProductListingViewModel
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public double Price { get; set; }

        public string PictureURL { get; set; }

        public string ProductType { get; set; }

        public string Description { get; set; }
    }
}
