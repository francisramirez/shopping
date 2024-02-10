

using Microsoft.EntityFrameworkCore;
using shopping.Domain.Entities.Production;

namespace shopping.Infrastructure.Context
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
