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
        private ICart _cart;
        private IDevCheckout _context;
        public OrderController(IDevCheckout context, ICart cart, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _cart = cart;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Shipping(Order order)
        {
            return View(order);
        }

        [AllowAnonymous]
        public async Task<IActionResult> FinalizeOrder(Order order)
        {
            
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            Cart cart = _cart.GetCart(user.Id);
            await _context.PopulateOrderProducts(cart, order);
            await _context.SaveOrder(order);
            await _cart.EmptyCart(cart);
            return View("ThankYou");
        }

    }
}
