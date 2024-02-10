
using shopping.Domain.Entities.Production;

namespace shopping.Infrastructure.Interfaces
{
    public interface IProductRespository
    {
        void Create(Product product);
        void Update(Product product);
        void Remove(Product product);
        List<Product> GetProducts();
        Product GetProduct(int productId);
    }
}
