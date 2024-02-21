

using shopping.Domain.Repository;

namespace shopping.Infrastructure.Core
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {

    }
}
