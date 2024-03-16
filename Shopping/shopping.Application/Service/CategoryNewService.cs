
using Microsoft.Extensions.Logging;
using shopping.Application.Contracts;
using shopping.Application.Core;
using shopping.Application.Dtos.Category;
using shopping.Application.Dtos.Enums;
using shopping.Application.Models.Category;
using shopping.Domain.Entities.Production;
using shopping.Infrastructure.Interfaces;

namespace shopping.Application.Service
{
    public class CategoryNewService : ICategoryNewService
    {
        private readonly ILogger<CategoryService> logger;
        private readonly ICategoryRepository categoryRepository;

        public CategoryNewService(ILogger<CategoryService> logger,
                               ICategoryRepository categoryRepository)
        {
            this.logger = logger;
            this.categoryRepository = categoryRepository;
        }
        public ServiceResult<CategoryGetModel> Get(int categoryId)
        {
            ServiceResult<CategoryGetModel> result = new ServiceResult<CategoryGetModel>();
            try
            {

                var category = this.categoryRepository.GetEntity(categoryId);

                result.Data = new CategoryGetModel()
                {
                    CategoryId = category.categoryid,
                    CreationDate = category.creation_date,
                    Description = category.description,
                    Name = category.categoryname
                };
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error obteniendo la categoria";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult<List<CategoryGetModel>> GetAll()
        {
            ServiceResult<List<CategoryGetModel>> result = new ServiceResult<List<CategoryGetModel>>();


            try
            {
                result.Data = this.categoryRepository.GetEntities().Select(cd => new CategoryGetModel()
                {
                    CategoryId = cd.categoryid,
                    CreationDate = cd.creation_date,
                    Description = cd.description,
                    Name = cd.categoryname

                }).ToList();


            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error obteniendo las categorias";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult<CategoryGetModel> Remove(CategoryRemoveDto categoryRemoveDto)
        {
            ServiceResult<CategoryGetModel> result = new ServiceResult<CategoryGetModel>();

            try
            {
                this.categoryRepository.Remove(new Category()
                {
                    categoryid = categoryRemoveDto.CategoryId,
                    delete_date = categoryRemoveDto.ChangeDate,
                    delete_user = categoryRemoveDto.UserId
                });
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error obteniendo la categoria";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult<CategoryGetModel> Save(CategoryAddDto categoryAddDto)
        {
            ServiceResult<CategoryGetModel> result = new ServiceResult<CategoryGetModel>();

            try
            {
                var resutlIsVali = this.IsValid(categoryAddDto, DtoAction.Save);
               
                if (!resutlIsVali.Success)
                {
                    result.Message = resutlIsVali.Message;
                    return result;
                }

                this.categoryRepository.Save(new Domain.Entities.Production.Category()
                {
                    categoryname = categoryAddDto.Name,
                    creation_date = categoryAddDto.ChangeDate,
                    creation_user = categoryAddDto.UserId,
                    description = categoryAddDto.Description
                });

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error guardando la categoria";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult<CategoryGetModel> Update(CategoryUpdteDto categoryUpdteDto)
        {
            ServiceResult<CategoryGetModel> result = new ServiceResult<CategoryGetModel>();

            try
            {
                var resutlIsVali = this.IsValid(categoryUpdteDto, DtoAction.Update);

                if (!resutlIsVali.Success)
                {
                    result.Message = resutlIsVali.Message;
                    return result;
                }


                this.categoryRepository.Update(new Category()
                {
                    categoryid = categoryUpdteDto.CategoryId,
                    categoryname = categoryUpdteDto.Name,
                    modify_date = categoryUpdteDto.ChangeDate,
                    modify_user = categoryUpdteDto.UserId,
                    description = categoryUpdteDto.Description,
                });

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error actualizando la categoria";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        private ServiceResult<string> IsValid(CategoryDtoBase categoryDtoBase, DtoAction action) 
        {
            ServiceResult<string> result = new ServiceResult<string>();
           
            if (string.IsNullOrEmpty(categoryDtoBase.Name))
            {
                result.Success = false;
                result.Message = "La categoria es requerida.";
                return result;
            }
            if (categoryDtoBase.Name.Length > 15)
            {
                result.Success = false;
                result.Message = "El nombre de la categoria debe tener 15 carácteres.";
                return result;
            }
            if (string.IsNullOrEmpty(categoryDtoBase.Description))
            {
                result.Success = false;
                result.Message = "La categoria es requerida.";
                return result;

            }
            if (categoryDtoBase.Description.Length > 200)
            {
                result.Success = false;
                result.Message = "La descripción de la categoria debe tener 200 carácteres.";
                return result;
            }

            if (action == DtoAction.Save)
            {
                if (this.categoryRepository.Exists(ca => ca.categoryname == categoryDtoBase.Name))
                {
                    result.Success = false;
                    result.Message = $"La categoria {categoryDtoBase.Name} ya existe.";
                    return result;
                }
            }

            return result;
        }
    }
}
