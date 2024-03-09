using shopping.Application.Core;
using shopping.Application.Models.Product;

namespace shopping.Application.Contracts
{
    public interface IProducService
    {
        ServiceResult<List<ProductGetModel>> GetProducts();
        ServiceResult<ProductGetModel> GetProduct(int productId);

        
    }
}
