﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PuffyAmiYumi.Data;
using PuffyAmiYumi.Models;
using PuffyAmiYumi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuffyAmiYumi.Components
{
    public class Cart : ViewComponent
    {
        private ICart _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public Cart(ICart context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }
        /// <summary>
        /// view Component
        /// </summary>
        /// <param name="purchased"></param>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            var userCart = _context.GetCart(user.Id);
            return View(userCart);
        }
    }
}
