using Microsoft.AspNetCore.Mvc;
using PuffyAmiYumi.Data;
using PuffyAmiYumi.Model;
using PuffyAmiYumi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuffyAmiYumi.Controllers
{
    public class HomeController : Controller
    {
        private IInventory _context;
        public HomeController(IInventory context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create(Product product)
        {
            _context.CreateProduct(product);
            return View();
        }
        public IActionResult GetByID(int id)
        {
            _context.GetProductByID(id);
            return View();
        }
    }
}
