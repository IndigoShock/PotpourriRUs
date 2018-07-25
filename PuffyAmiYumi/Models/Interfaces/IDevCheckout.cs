using PuffyAmiYumi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuffyAmiYumi.Models.Interfaces
{
    public interface IDevCheckout
    {
        Task<Order> PopulateOrderProducts(Cart cart, Order order);
        void NewOrder(Order order);

    }
}
