using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PuffyAmiYumi.Data;
using PuffyAmiYumi.Models;
using PuffyAmiYumi.Models.Interfaces;

namespace PuffyAmiYumi.Controllers
{
    [Authorize]
    public class ShopController : Controller
    {
        private readonly YumiDbContext _context;
        private ICart _cart;
        private UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public ShopController(YumiDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ICart cart)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _cart = cart;
        }
        [AllowAnonymous]
        public async Task<IActionResult> MyCart(int id)
        {
            Product product = _context.Products.First(f => f.ID == id);
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            Cart cart = _context.Carts.FirstOrDefault(c => c.UserTag == user.Id);
            if (cart == null)
            {
                cart = new Cart();
                cart.UserTag = user.Id;
                cart.CartItems = new List<CartItem>();
                await _context.Carts.AddAsync(cart);
                await _context.SaveChangesAsync();
            }
            _cart.AddProductToCart(user, cart, product);
            await _context.SaveChangesAsync();

            return View(cart);
        }
        //public async Task<IActionResult> MyCart()
        //{
        //    var user = await _userManager.FindByEmailAsync(User.Identity.Name);
        //    Cart cart = _context.Carts.FirstOrDefault(c => c.UserTag == user.Id);
        //    return View(cart);
        //}

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        [Authorize(Policy = "HasEmail")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProductName,Price,ImageURL,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ProductName,Price,ImageURL,Stock")] Product product)
        {
            if (id != product.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [AllowAnonymous]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ID == id);
        }
    }
}
