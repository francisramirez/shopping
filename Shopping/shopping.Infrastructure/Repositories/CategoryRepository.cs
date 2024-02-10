


using shopping.Domain.Entities.Production;
using shopping.Infrastructure.Context;
using shopping.Infrastructure.Exceptions;
using shopping.Infrastructure.Interfaces;

namespace shopping.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopContext context;

        public CategoryRepository(ShopContext context)
        {
            this.context = context;
        }
        public void Create(Category category)
        {
            try
            {

                if (context.Categories.Any(ca => ca.categoryname == category.categoryname))
                    throw new CategoryException("La categoria se encuentra registrada.");

          

                this.context.Categories.Add(category);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Category> GetCategories()
        {
            return this.context.Categories
                               .Where(ca => !ca.deleted)
                               .ToList();
        }

        public Category GetCategory(int categoryId)
        {
            return this.context.Categories.Find(categoryId);
           
        }

        public void Remove(Category category)
        {
            try
            {
                var categoryToRemoe = this.GetCategory(category.categoryid);

                categoryToRemoe.deleted = true;
                categoryToRemoe.delete_date = category.delete_date;
                categoryToRemoe.delete_user = category.delete_user;

                this.context.Categories.Update(categoryToRemoe);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Category category)
        {
            try
            {
                var categoryToUpdate = this.GetCategory(category.categoryid);

                categoryToUpdate.categoryname = category.categoryname;
                categoryToUpdate.description = category.description;
                categoryToUpdate.modify_user = category.modify_user;
                categoryToUpdate.modify_date = category.modify_date;

                this.context.Categories.Update(categoryToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
