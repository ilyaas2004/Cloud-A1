using Microsoft.AspNetCore.Mvc;
using Cloud_A1.Models;
namespace Cloud_A1.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public productTable1 prodtbl = new productTable1();



        [HttpPost]
        public ActionResult MyWork(productTable1 products)
        {
            var result2 = prodtbl.insert_product(products);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult MyWork()
        {
            return View(prodtbl);
        }
    }
}

