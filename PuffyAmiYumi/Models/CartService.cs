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

        public Cart AddProductToCart(ApplicationUser user, Cart cart, Product product)
        {
            CartItem item = new CartItem();
            item.CartID = cart.ID;
            item.ProductID = product.ID;
            item.ProductName = product.ProductName;
            item.ProductIMG = product.ImageURL;
            item.Quantity++;
            item.Price = product.Price;
            
            
            cart.CartItems.Add(item);
            _context.CartItems.Add(item);
            _context.SaveChanges();
            
            return cart;
        }
        public Cart GetCart(string id)
        {
            var cart = _context.Carts.FirstOrDefault(x => x.UserTag == id);
            if(cart == null)
            {
                cart = new Cart();
                cart.UserTag = id;
                _context.Carts.Add(cart);
            }
            cart.CartItems = GetCartItems(cart.ID);
            _context.SaveChanges();
            return cart;
        }
        public List<CartItem> GetCartItems(int id)
        {
            try
            {
            var x = _context.CartItems.OrderByDescending(a => a.CartID == id).ToList();
            }
            catch(Exception)
            {
                return new List<CartItem>();
            }
            return _context.CartItems.OrderByDescending(a => a.CartID == id).ToList();
        }
        public Product GetProduct(int id)
        {
            return _context.Products.First(f => f.ID == id);
        }

        public void DeleteCartItem(int id)
        {
            var item = _context.CartItems.FirstOrDefault(f => f.ID == id);
            _context.CartItems.Remove(item);
            _context.SaveChanges();
        }
    }
}
