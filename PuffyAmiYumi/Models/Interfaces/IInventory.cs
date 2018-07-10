using Microsoft.AspNetCore.Mvc;
using PuffyAmiYumi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuffyAmiYumi.Models.Interfaces
{
    public interface IInventory
    {
        Task<IActionResult> CreateProduct(Product product);
        Task<IActionResult> GetProductByID(int ID);
        Task<IActionResult> GetProduct();
        Task<IActionResult> UpdateProduct(int ID, Product product);
        Task<IActionResult> DeleteProduct(int ID);
    }
}
