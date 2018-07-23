using Microsoft.EntityFrameworkCore;
using PuffyAmiYumi.Models;

namespace PuffyAmiYumi.Data
{
    public class YumiDbContext : DbContext
    {
        public YumiDbContext(DbContextOptions<YumiDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {  // <Product> ---> ProductName --- Price --- ImageURL --- Stock
            modelBuilder.Entity<Product>().HasData(
                new { ID = 1, ProductName = "Karma-Patchouli-Potpourri", Price = 11.99m, ImageURL = "asset/Patchouli.jpg", Stock = 100 },
                new { ID = 2, ProductName = "Karma-Rose-Potpourri", Price = 11.99m, ImageURL = "asset/RoseScented.jpg", Stock = 100 },
                new { ID = 3, ProductName = "Karma-Vanilla-Potpourri", Price = 11.99m, ImageURL = "asset/VanillaScented.jpg", Stock = 100 },
                new { ID = 4, ProductName = "Karma-Jasmine-Potpourri", Price = 11.99m, ImageURL = "asset/JasmineScented.jpg", Stock = 100 },
                new { ID = 5, ProductName = "Karma-Sandalwood-Potpourri", Price = 11.99m, ImageURL = "asset/Sandalwood.jpg", Stock = 100 },
                new { ID = 6, ProductName = "Karma-Lavender-Potpourri", Price = 11.99m, ImageURL = "asset/Lavender.jpg", Stock = 100 },
                new { ID = 7, ProductName = "Esscents-Sandalwood-Spice-Potpourri", Price = 12.99m, ImageURL = "asset/SandalwoodSpice.jpg", Stock = 100 },
                new { ID = 8, ProductName = "Esscents-Geranium-Potpourri", Price = 12.99m, ImageURL = "asset/Geranium.jpg", Stock = 100 },
                new { ID = 9, ProductName = "Esscents-Morning-Blossom-Potpourri", Price = 12.99m, ImageURL = "asset/MorningBlossom.jpg", Stock = 100 },
                new { ID = 10, ProductName = "Esscents-Jasmine-Tea-Potpourri", Price = 12.99m, ImageURL = "asset/JasmineTea.jpg", Stock = 100 }
                );
        }
    }
}