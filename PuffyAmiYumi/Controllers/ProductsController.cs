using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PuffyAmiYumi.Models;
using PuffyAmiYumi.Models.Interfaces;
using System.Threading.Tasks;

namespace PuffyAmiYumi.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class ProductsController : Controller
    {
        private IInventory _context;

        private readonly IConfiguration Configuration;

        public ProductsController(IInventory context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        [HttpGet("/admin/products/allProducts")]
        public IActionResult ViewAllProducts()
        {
            var products = _context.GetProduct();

            return View(products);
        }

        // GET: Admin/Create
        [HttpGet("/admin/products/Create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet("/admin/products")]
        public IActionResult Index()
        {
            return View(_context.GetProduct());
        }

        // GET: Products/Details/5
        [HttpGet("/admin/products/Details")]
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var product = _context.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost("/admin/products/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,SKU,Name,Price,Stock,Description,Image")] Product product)
        {
            if (ModelState.IsValid)
            {
                await _context.CreateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        [HttpGet("/admin/products/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var product = _context.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        //GET: Products/Edit/5
        [HttpPost("/admin/products/Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID, ProductName,Price,Stock,ImageUrl")] Product product)
        {
            if (id != product.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.UpdateProduct(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (id != product.ID)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Admin");
            }
            return View(product);
        }

        //GET: Products/Delete/5
        [HttpGet("/admin/products/Delete")]
        public IActionResult Delete(int id)
        {
            var product = _context.GetProductById(id);
            _context.DeleteProduct(product.ID);
            return RedirectToAction("Index", "Admin");
        }
    }
}