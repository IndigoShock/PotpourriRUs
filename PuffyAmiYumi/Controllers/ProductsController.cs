using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Xml;
using PuffyAmiYumi.Models.Interfaces;

namespace PuffyAmiYumi.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class ProductsController : Controller
    {
        private IInventory _context;

        private readonly IConfiguration Configuration;
        // this connects the Inventory interface with our products controller
        public ProductsController(IInventory context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public IActionResult ViewAllProducts()
        {
            var products = _context.GetProduct();

            return View(products);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}