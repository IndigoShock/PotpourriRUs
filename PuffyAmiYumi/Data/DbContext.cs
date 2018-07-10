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
    }
}
