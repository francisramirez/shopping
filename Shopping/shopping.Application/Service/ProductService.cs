

using shopping.Application.Contracts;
using shopping.Application.Core;
using shopping.Application.Models.Product;

namespace shopping.Application.Service
{
    internal class ProductService : IProducService
    {
        public ServiceResult<ProductGetModel> GetProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<List<ProductGetModel>> GetProducts()
        {
            ServiceResult<List<ProductGetModel>> result = new ServiceResult<List<ProductGetModel>>();
            return result;
        }
    }
}
