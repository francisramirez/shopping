

using Microsoft.EntityFrameworkCore;
using shopping.Domain.Entities.Production;

namespace shopping.Infrastructure.Context
{
    public partial class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }

        #region "DbSets"
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        #endregion

        #region "Procedures"
        #endregion
    }
}


