using Microsoft.AspNetCore.Mvc;
using PuffyAmiYumi.Data;
using PuffyAmiYumi.Model;
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

        public Task<IActionResult> CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetProduct()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetProductByID(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> UpdateProduct(int ID, Product product)
        {
            throw new NotImplementedException();
        }
        public Task<IActionResult> DeleteProduct(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
