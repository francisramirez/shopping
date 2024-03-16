using shopping.Application.Dtos.Category;
using shopping.Application.Models.Category;

namespace shopping.Application.Contracts
{
    public interface ICategoryNewService : IBaseService<CategoryAddDto,CategoryUpdteDto,CategoryRemoveDto,CategoryGetModel>
    {
    }
}
