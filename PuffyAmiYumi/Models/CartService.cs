using PuffyAmiYumi.Data;
using PuffyAmiYumi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuffyAmiYumi.Models
{
    public class CartService : ICart
    {
        private YumiDbContext _context;
        public CartService(YumiDbContext context)
        {
            _context = context;
        }
        public List<Product> GetCartItems()
        {
            return _context.Products.OrderByDescending(a => a.ID).ToList();
        }
    }
}
