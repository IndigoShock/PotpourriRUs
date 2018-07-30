using Microsoft.AspNetCore.Mvc;
using PuffyAmiYumi.Data;
using PuffyAmiYumi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuffyAmiYumi.Models
{
    public class DevInven : IInventory
    {
        private YumiDbContext _context;

        public DevInven(YumiDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public List<Product> GetProduct()
        {
            var makeList = _context.Products.ToList();
            return makeList;
        }

        public Product GetProductById(int? id) => _context.Products.Single<Product>(p => p.ID == id);

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            Product product = _context.Products.Single(p => p.ID == id);
            _context.Products.Remove(product);
            _context.SaveChangesAsync();
        }
    }
}