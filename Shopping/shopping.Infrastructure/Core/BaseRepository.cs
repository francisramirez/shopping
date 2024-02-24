using Microsoft.EntityFrameworkCore;
using shopping.Domain.Repository;
using shopping.Infrastructure.Context;

namespace shopping.Infrastructure.Core
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ShopContext context;
        private readonly DbSet<TEntity> DbEntity;
        protected BaseRepository(ShopContext context)
        {
            this.context = context;
            this.DbEntity = context.Set<TEntity>();

        }
        public virtual bool Exists(Func<TEntity, bool> filter)
        {
            return DbEntity.Any(filter);
        }

        public virtual List<TEntity> FindAll(Func<TEntity, bool> filter)
        {
            return DbEntity.Where(filter).ToList();
        }

        public virtual List<TEntity> GetEntities()
        {
            return DbEntity.ToList();
        }

        public virtual TEntity GetEntity(int id)
        {
            return DbEntity.Find(id);
        }

        public void Remove(TEntity entity)
        {
            DbEntity.Update(entity);
            this.context.SaveChanges();
        }

        public virtual void Save(TEntity entity)
        {
            DbEntity.Add(entity);
            context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            DbEntity.Update(entity);
            context.SaveChanges();
        }
    }
}
