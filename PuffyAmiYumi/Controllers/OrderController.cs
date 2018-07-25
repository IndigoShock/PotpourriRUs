using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PuffyAmiYumi.Models;
using PuffyAmiYumi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuffyAmiYumi.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IDevCheckout _context;
        public OrderController(IDevCheckout context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //public IActionResult Index(Cart cart)
        //{

        //    Order order = _context.NewOrder(cart).Result;
        //    return RedirectToAction("Shipping", order);
        //}
        public IActionResult Shipping(Order order)
        {
            return View(order);
        }

    }
}
