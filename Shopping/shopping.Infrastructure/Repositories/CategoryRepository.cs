


using Microsoft.Extensions.Logging;
using shopping.Domain.Entities.Production;
using shopping.Infrastructure.Context;
using shopping.Infrastructure.Core;
using shopping.Infrastructure.Exceptions;
using shopping.Infrastructure.Interfaces;

namespace shopping.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly ShopContext context;
        private readonly ILogger<CategoryRepository> logger;

        public CategoryRepository(ShopContext context, ILogger<CategoryRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public override List<Category> GetEntities()
        {
            return base.GetEntities().Where(ca => !ca.deleted).ToList();
        }
        public override void Update(Category entity)
        {
            try
            {
                var categoryToUpdate = this.GetEntity(entity.categoryid);

                if (categoryToUpdate is null)
                    throw new CategoryException("La categoria no existe.");



                categoryToUpdate.categoryname = entity.categoryname;
                categoryToUpdate.description = entity.description;
                categoryToUpdate.modify_user = entity.modify_user;
                categoryToUpdate.modify_date = entity.modify_date;

                this.context.Categories.Update(categoryToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error actualizando la categoria", ex.ToString());
            }
        }
        public override void Save(Category entity)
        {
            try
            {


                if (context.Categories.Any(ca => ca.categoryname == entity.categoryname))
                    throw new CategoryException("La categoria se encuentra registrada.");


                this.context.Categories.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error creando la categoria", ex.ToString());
            }
        }

        public override void Remove(Category entity)
        {
            try
            {
                Category categoryToRemove = this.GetEntity(entity.categoryid);

                if (categoryToRemove is null)
                    throw new CategoryException("La categoria no existe.");

                categoryToRemove.delete_date = entity.delete_date;
                categoryToRemove.delete_user = entity.delete_user;
                categoryToRemove.deleted = true;

                this.context.Categories.Update(categoryToRemove);
                this.context.SaveChanges();
                
            }
            catch (Exception ex)
            {
                this.logger.LogError("", ex.ToString());
            }
        }

    }
}
