namespace SmartShop.Models.Product
{
    public class AllProductsViewModel
    {
        public IEnumerable<string> ProductTypes { get; set; }

        public string Search { get; set; }

        public IEnumerable<ProductListingViewModel> Products { get; set; } = new List<ProductListingViewModel>();

    }
}
