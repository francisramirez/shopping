

using shopping.Domain.Entities.Production;
using shopping.Infrastructure.Context;
using shopping.Infrastructure.Interfaces;

namespace shopping.Infrastructure.Repositories
{
    public class ProductRepository : IProductRespository
    {
        private readonly ShopContext context;

        public ProductRepository(ShopContext context)
        {
            this.context = context;
        }
        public void Create(Product product)
        {
            try
            {
                this.context.Products.Add(product);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Product GetProduct(int productId)
        {
            return this.context.Products.Find(productId);
        }

        public List<Product> GetProducts()
        {
            return this.context.Products.ToList();
        }

        public void Remove(Product product)
        {
            try
            {

                Product producttoRemove = this.GetProduct(product.productid);
                this.context.Products.Remove(producttoRemove);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Update(Product product)
        {
            try
            {
                Product productToUpdate = this.GetProduct(product.productid);

                productToUpdate.supplierid = product.supplierid;
                productToUpdate.modify_date = product.modify_date;
                productToUpdate.modify_user = product.modify_user;
                productToUpdate.unitprice = product.unitprice;
                productToUpdate.categoryid = product.categoryid;
                productToUpdate.discontinued = product.discontinued;
                productToUpdate.productname = product.productname;

                this.context.Products.Update(productToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
