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
    public class CheckoutController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IDevCheckout _context;
        private ICart _cart;

        public CheckoutController(ICart cart, IDevCheckout context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _cart = cart;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Checkout()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult CollectOrderInformation(Order order)
        {
            return RedirectToAction("GetOrderInformation", order);
        }

        [AllowAnonymous]
        public async Task<IActionResult> GetOrderInformation(Order order)
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            
            Cart cart = _cart.GetCart(user.Id);
            await _context.PopulateOrderProducts(cart, order);
            return RedirectToAction("ConfirmCheckout", order);
        }

        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public IActionResult ConfirmCheckout(Order order)
        {
            return View(order);
        }

        [HttpGet]
        public IActionResult Payment()
        {
            return View();
        }
    }
}
