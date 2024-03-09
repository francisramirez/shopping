using shopping.Application.Core;
using shopping.Application.Dtos.Category;
using shopping.Application.Models.Category;

namespace shopping.Application.Contracts
{
    public interface ICategoryService
    {
        ServiceResult<List<CategoryGetModel>> GetCategories();
        ServiceResult<CategoryGetModel> GetCategory(int categoryId);
        ServiceResult<CategoryGetModel> SaveCategory(CategoryDto categoryDto);
        ServiceResult<CategoryGetModel> UpdateCategory(CategoryDto categoryDto);
        ServiceResult<CategoryGetModel> RemoveCategory(CategoryDto categoryDto);
    }
}
