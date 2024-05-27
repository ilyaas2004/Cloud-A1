using Cloud_A1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cloud_A1.Controllers
{
    public class ProductDisplayController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var products = ProductDisplayModel.SelectProducts();
            return View(products);
        }

    }
}

