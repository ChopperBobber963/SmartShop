using Microsoft.AspNetCore.Mvc;
using SmartShop.Data;
using SmartShop.Models;
using SmartShop.Models.Product;
using System.Diagnostics;

namespace SmartShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly SmartShopDbContext dbContext;

        public HomeController(SmartShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}