﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PuffyAmiYumi.Data;
using PuffyAmiYumi.Models;
using System.Threading.Tasks;

namespace PuffyAmiYumi.Components
{
    public class SubmittedOrders : ViewComponent
    {
        private readonly YumiDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public SubmittedOrders(YumiDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }

        /// <summary>
        /// Find orders in the YumiDatabase
        /// </summary>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            var showOrders = _context.Orders;
            return View(showOrders);
        }
    }
}