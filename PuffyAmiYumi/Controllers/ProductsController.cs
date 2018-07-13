using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PuffyAmiYumi.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class ProductsController : Controller
    {
        //only accessible by Admin

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details()
        {
            return View();
        }

        // GET: Admin/Create
        [HttpPost]
        public ActionResult Create()
        {
            return View();
        }

        // GET: Admin/Edit/5
        [HttpPut]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // GET: Admin/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}