using Microsoft.AspNetCore.Mvc;

namespace PuffyAmiYumi.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}