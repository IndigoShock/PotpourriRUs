using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private IConfiguration _config;

        public CheckoutController(IConfiguration config, ICart cart, IDevCheckout context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _config = config;
            _cart = cart;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        /// <summary>
        /// Brings the user to the Checkout Page
        /// </summary>
        /// <returns>Checkout Page</returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Checkout()
        {
            return View();
        }
        /// <summary>
        /// grabs the info the user (might be useless might delete)
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public IActionResult CollectOrderInformation(Order order)
        {
            return RedirectToAction("GetOrderInformation", order);
        }
        /// <summary>
        /// Finds the signed in User, then finds the cart and populates it, lastly displays a confirm checkout page
        /// </summary>
        /// <param name="order">The information about their shipping/billing address</param>
        /// <returns>A Last Confirm Order page before the order is finalized</returns>
        [AllowAnonymous]
        public async Task<IActionResult> GetOrderInformation(Order order)
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            
            Cart cart = _cart.GetCart(user.Id);
            await _context.PopulateOrderProducts(cart, order);
            return RedirectToAction("ConfirmCheckout", order);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmCheckout(Order order)
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            Payment payment = new Payment(_config);
            Cart cart = _cart.GetCart(user.Id);
            await _context.PopulateOrderProducts(cart, order);
            payment.RunPayment(order, user);
            order.CreditCard = $"{order.CreditCard.Substring(0, 4)}***********";
            return View(order);
        }

        [HttpGet]
        public IActionResult Payment()
        {
            return View();
        }
    }
}
