using PuffyAmiYumi.Data;
using PuffyAmiYumi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuffyAmiYumi.Models
{
    public class DevCheckout : IDevCheckout
    {
        private YumiDbContext _context;
        public DevCheckout(YumiDbContext context)
        {
            _context = context;
        }

        public async Task<Order> NewOrder(Cart cart, Order order)
        {
            order.Products = new List<OrderItems>();
            //await _context.Orders.AddAsync(order);
            //await _context.SaveChangesAsync();
            await PopulateOrderProducts(cart, order);
            return order;
        }

        public void NewOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> PopulateOrderProducts(Cart cart, Order order)
        {
                order.Products = new List<OrderItems>();
            foreach (CartItem item in cart.CartItems)
            {
                OrderItems OrderItem = new OrderItems();
                OrderItem.ItemID = item.ProductID;
                OrderItem.OrderID = order.ID;
                OrderItem.ItemName = item.ProductName;
                OrderItem.Price = item.Price;
                OrderItem.TotalCost = OrderItem.Price * item.Quantity;
                OrderItem.Quantity = item.Quantity;
                order.Products.Add(OrderItem);
                //await _context.OrderItems.AddAsync(OrderItem);
            }
                //await _context.SaveChangesAsync();
                return order;
        }

        public async Task<Order> SaveOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
