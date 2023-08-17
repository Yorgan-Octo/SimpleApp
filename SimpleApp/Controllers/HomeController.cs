using Microsoft.AspNetCore.Mvc;

namespace SimpleApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult FileDov()
        {

            byte[] fileBute = System.IO.File.ReadAllBytes("App_Data/data.txt");

            return File(fileBute, "application/txt", "Save All Product.txt");
        }



    }
}
