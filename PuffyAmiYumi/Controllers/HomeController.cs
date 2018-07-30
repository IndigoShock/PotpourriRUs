using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PuffyAmiYumi.Data;
using PuffyAmiYumi.Models;
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
            _context = context;
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
            _context.GetProductById(id);
            return View();
        }

        public IActionResult GetAll()
        {
            _context.GetProduct();
            return View();
        }

        public IActionResult Update(Product product)
        {
            _context.UpdateProduct(product);
            return View();
        }
    }
}