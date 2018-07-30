using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PuffyAmiYumi.Models.Interfaces
{
    public interface IInventory
    {
        Task<Product> CreateProduct(Product product);

        Product GetProductById(int? id);

        List<Product> GetProduct();

        void UpdateProduct(Product product);

        void DeleteProduct(int ID);
    }
}