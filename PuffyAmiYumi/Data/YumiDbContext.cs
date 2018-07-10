using Microsoft.EntityFrameworkCore;
using PuffyAmiYumi.Model;
using PuffyAmiYumi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuffyAmiYumi.Data
{
    public class YumiDbContext:DbContext
    {
        public YumiDbContext(DbContextOptions<YumiDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {  // <Product> ---> ProductName --- Price --- ImageURL --- Stock
            modelBuilder.Entity<Product>().HasData(
                new { ID = 1, ProductName = "", Price = 0m, ImageURL = "", Stock = 0 },
                new { ID = 2, ProductName = "", Price = 0m, ImageURL = "", Stock = 0 },
                new { ID = 3, ProductName = "", Price = 0m, ImageURL = "", Stock = 0 },
                new { ID = 4, ProductName = "", Price = 0m, ImageURL = "", Stock = 0 },
                new { ID = 5, ProductName = "", Price = 0m, ImageURL = "", Stock = 0 },
                new { ID = 6, ProductName = "", Price = 0m, ImageURL = "", Stock = 0 },
                new { ID = 7, ProductName = "", Price = 0m, ImageURL = "", Stock = 0 },
                new { ID = 8, ProductName = "", Price = 0m, ImageURL = "", Stock = 0 },
                new { ID = 9, ProductName = "", Price = 0m, ImageURL = "", Stock = 0 },
                new { ID = 10, ProductName = "", Price = 0m, ImageURL = "", Stock = 0 }
                );
        }
    }
}