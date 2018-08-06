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
    public class CartController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private ICart _context;
        public CartController(ICart context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        /// <summary>
        /// Deletes the CartItem from their cart
        /// </summary>
        /// <param name="id">The Id of the cart-Item you want to Remove</param>
        /// <returns>Their Cart Page, which displays all the items in the cart</returns>
        [AllowAnonymous]
        public IActionResult Delete(int id)
        {
            _context.DeleteCartItem(id);
            return View("Index");
        }
        /// <summary>
        /// Brings user to Checkout Page
        /// </summary>
        /// <param name="id">Takes in a Cart</param>
        /// <returns>View</returns>
        [AllowAnonymous]
        public async Task<IActionResult> Checkout()
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);

            Cart cart = _context.GetCart(user.Id);
            return RedirectToAction("Index", "Order", cart);
        }
        /// <summary>
        /// Finds the Cart and its contents that is associated with the user
        /// </summary>
        /// <returns>A page to display all the items</returns>
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);

            var cart = _context.GetCart(user.Id);
            return View(cart);
        }
        /// <summary>
        /// Adds a specific Item to the user's cart
        /// </summary>
        /// <param name="id">ID of the item they want to add</param>
        /// <returns>Page that contains their cart and all its' contents</returns>
        [AllowAnonymous]
        public async Task<IActionResult> AddToCart(int id)
        {
            ApplicationUser user;
            try
            {
            user = await _userManager.FindByEmailAsync(User.Identity.Name);

            }
            catch
            {
                return RedirectToAction("Login", "Account");
            }
            var cart = _context.GetCart(user.Id);
            Product product = _context.GetProduct(id);

            var x = _context.AddProductToCart(user, cart, product);
            return View("Index", cart);
        }
    }
}
