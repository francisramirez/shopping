

using Microsoft.Extensions.Logging;
using shopping.Domain.Entities.Production;
using shopping.Infrastructure.Context;
using shopping.Infrastructure.Core;
using shopping.Infrastructure.Interfaces;
using shopping.Infrastructure.Models;

namespace shopping.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRespository
    {
        private readonly ShopContext context;
        private readonly ILogger<ProductRepository> logger;

        public ProductRepository(ShopContext context, ILogger<ProductRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }
        public override bool Exists(Func<Product, bool> filter)
        {
            return base.Exists(filter);
        }
        public override void Save(Product entity)
        {
            base.Save(entity);
        }
        public override void Update(Product entity)
        {
            base.Update(entity);
        }
        public override void Remove(Product entity)
        {
            base.Remove(entity);
        }
        public override List<Product> FindAll(Func<Product, bool> filter)
        {
            return base.FindAll(filter);
        }
        public override List<Product> GetEntities()
        {
            return base.GetEntities();
        }
        public override Product GetEntity(int id)
        {
            return base.GetEntity(id);
        }

        public List<ProductModel> GetProductsByCategory(int categoryId)
        {
            List<ProductModel> products = new List<ProductModel>();
            try
            {
                products = (from pro in this.context.Products
                             join ca in this.context.Categories on pro.categoryid equals ca.categoryid
                             where pro.categoryid == categoryId
                             select new ProductModel()
                             {
                                 CategoryId = ca.categoryid,
                                 CatetoryName = ca.categoryname,
                                 Discontinued = pro.discontinued,
                                 ProductId = pro.productid,
                                 ProductName = pro.productname,
                                 UnitPrice = pro.unitprice
                             }).ToList();

                return products;

            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo los productos", ex.ToString());
            }

            return products;
        }

    }
}
