using Microsoft.AspNetCore.Identity;
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
        private YumiDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public Cart(YumiDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(bool purchased)
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            var userCart = _context.Carts.Where(x => x.UserEmail == user.Id)
                                         .Include(p => p.CartItems)
                                         .ThenInclude(x => x.Product).First();
            return View(userCart);
        }
    }
}
