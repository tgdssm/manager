using manager.Models;
using Microsoft.EntityFrameworkCore;

namespace manager.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<ProductSize> ProductSize { get; set; }
        public DbSet<Product> Product { get; set; }


    }
}
