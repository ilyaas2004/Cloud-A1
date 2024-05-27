using Cloud_A1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cloud_A1.Controllers
{
    public class userController : Controller
    {
        
        public userTable2 usrtbl = new userTable2();
   

        [HttpPost]
        public ActionResult AboutUs(userTable2 Users)
        {
            var result = usrtbl.insert_User(Users);
            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        public ActionResult AboutUs()
        {
            return View(usrtbl);
        }


    }

}

