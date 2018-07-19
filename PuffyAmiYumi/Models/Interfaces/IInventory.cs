using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PuffyAmiYumi.Models.Interfaces
{
    public interface IInventory
    {
        Task<IActionResult> CreateProduct(Product product);

        Task<IActionResult> GetProductByID(int ID);

        List<Product> GetProduct();

        Task<IActionResult> UpdateProduct(int ID, Product product);

        Task<IActionResult> DeleteProduct(int ID);
    }
}