using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuffyAmiYumi.Models.Interfaces
{
    public interface ICart
    {

        List<CartItem> GetCartItems(int id);
        Cart AddProductToCart(ApplicationUser user, Cart cart, Product product);
        Cart GetCart(string id);
        Product GetProduct(int id);
        void DeleteCartItem(int id);
    }
}
