﻿using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
        public async Task<IActionResult> Index()
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