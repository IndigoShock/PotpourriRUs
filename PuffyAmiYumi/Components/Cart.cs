using Microsoft.AspNetCore.Mvc;
using PuffyAmiYumi.Data;
using PuffyAmiYumi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuffyAmiYumi.Components
{
    public class Cart : ViewComponent
    {
        private YumiDbContext _context;
        public Cart(YumiDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Product product)
        {
            //var items = await _context.Products.Where(p => p.ID == product).ToList();
            return View();
        }
    }
}
