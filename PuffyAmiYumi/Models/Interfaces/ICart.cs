using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuffyAmiYumi.Models.Interfaces
{
    public interface ICart
    {
        List<Product> GetCartItems();
        Cart AddProductToCart(ApplicationUser user, Cart cart, Product product);
    }
}
