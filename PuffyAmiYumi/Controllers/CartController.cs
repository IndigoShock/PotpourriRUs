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

        //public async Task<IActionResult> MyCart(int id)
        //{
        //    Product product = _context.Products.First(f => f.ID == id);
        //    var user = await _userManager.FindByEmailAsync(User.Identity.Name);
        //    Cart cart = _context.Carts.FirstOrDefault(c => c.UserTag == user.Id);
        //    if (cart == null)
        //    {
        //        cart = new Cart();
        //        cart.UserTag = user.Id;
        //        cart.CartItems = new List<CartItem>();
        //        await _context.Carts.AddAsync(cart);
        //        await _context.SaveChangesAsync();
        //    }
        //    await _cart.AddProductToCart(user, cart, product);
        //    await _context.SaveChangesAsync();

        //    return View(cart);
        [AllowAnonymous]
        public async Task<IActionResult> Index(int id)
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);

            var cart = _context.GetCart(user.Id);
            return View(cart);
        }
        [AllowAnonymous]
        public async Task<IActionResult> AddToCart(int id)
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            var cart = _context.GetCart(user.Id);
            Product product = _context.GetProduct(id);

            var x = _context.AddProductToCart(user, cart, product);
            return View("Index", cart);
        }
    }
}
