

using shopping.Domain.Entities.Production;
using shopping.Domain.Repository;
using shopping.Infrastructure.Models;

namespace shopping.Infrastructure.Interfaces
{
    public interface IProductRespository : IBaseRepository<Product>
    {
        List<ProductModel> GetProductsByCategory(int categoryId);
       
    }
}
