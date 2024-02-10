

using shopping.Domain.Repository;

namespace shopping.Infrastructure.Core
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {

    }
}
