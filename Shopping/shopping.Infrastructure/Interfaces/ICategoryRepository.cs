
using shopping.Domain.Entities.Production;

namespace shopping.Infrastructure.Interfaces
{
    public interface ICategoryRepository
    {
        void Create(Category category);
        void Update(Category category);
        void Remove(Category category);
        List<Category> GetCategories();
        Category GetCategory(int categoryId);
    }
}
