using shopping.Application.Core;
 
namespace shopping.Application.Contracts
{
    public interface IBaseService<TDtoAdd, TDtoUpdate, TDtoRemove, TModel>   
    {
        ServiceResult<List<TModel>> GetAll();
        ServiceResult<TModel> Get(int categoryId);
        ServiceResult<TModel> Save(TDtoAdd categoryAddDto);
        ServiceResult<TModel> Update(TDtoUpdate categoryUpdteDto);
        ServiceResult<TModel> Remove(TDtoRemove categoryRemoveDto);

    }
}
