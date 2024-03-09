
using Microsoft.Extensions.Logging;
using shopping.Application.Contracts;
using shopping.Application.Core;
using shopping.Application.Dtos.Category;
using shopping.Application.Exceptions;
using shopping.Application.Models.Category;
using shopping.Domain.Entities.Production;
using shopping.Infrastructure.Interfaces;

namespace shopping.Application.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ILogger<CategoryService> logger;
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ILogger<CategoryService> logger,
                               ICategoryRepository categoryRepository)
        {
            this.logger = logger;
            this.categoryRepository = categoryRepository;
        }
        public ServiceResult<List<CategoryGetModel>> GetCategories()
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

        public ServiceResult<CategoryGetModel> GetCategory(int categoryId)
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

        public ServiceResult<CategoryGetModel> RemoveCategory(CategoryDto categoryDto)
        {
            ServiceResult<CategoryGetModel> result = new ServiceResult<CategoryGetModel>();
            
            try
            {
                this.categoryRepository.Remove(new Category()
                {
                    categoryid = categoryDto.CategoryId,
                    delete_date = categoryDto.DeleteDate,
                    delete_user = categoryDto.DeleteUser
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

        public ServiceResult<CategoryGetModel> SaveCategory(CategoryDto categoryDto)
        {
            ServiceResult<CategoryGetModel> result = new ServiceResult<CategoryGetModel>();

            try
            {

                if (string.IsNullOrEmpty(categoryDto.CategoryName))
                {
                    result.Success = false;
                    result.Message = "La categoria es requerida.";
                    return result;
                }
                if (categoryDto.CategoryName.Length > 15)
                {
                    result.Success = false;
                    result.Message = "El nombre de la categoria debe tener 15 carácteres.";
                    return result;
                }
                if (string.IsNullOrEmpty(categoryDto.Description))
                {
                    result.Success = false;
                    result.Message = "La categoria es requerida.";
                    return result;

                }
                if (categoryDto.Description.Length > 200)
                {
                    result.Success = false;
                    result.Message = "La descripción de la categoria debe tener 200 carácteres.";
                    return result;
                }

                if (this.categoryRepository.Exists(ca => ca.categoryname == categoryDto.CategoryName))
                {
                    result.Success = false;
                    result.Message = $"La categoria { categoryDto.CategoryName } ya existe.";
                    return result;
                }

                this.categoryRepository.Save(new Domain.Entities.Production.Category()
                {
                    categoryname = categoryDto.CategoryName,
                    creation_date = categoryDto.CreationDate,
                    creation_user = categoryDto.CreationUser,
                    description = categoryDto.Description
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

        public ServiceResult<CategoryGetModel> UpdateCategory(CategoryDto categoryDto)
        {
            ServiceResult<CategoryGetModel> result = new ServiceResult<CategoryGetModel>();

            try
            {


                if (string.IsNullOrEmpty(categoryDto.CategoryName))
                {
                    result.Success = false;
                    result.Message = "La categoria es requerida.";
                    return result;
                }
                if (categoryDto.CategoryName.Length > 15)
                {
                    result.Success = false;
                    result.Message = "El nombre de la categoria debe tener 15 carácteres.";
                    return result;
                }
                if (string.IsNullOrEmpty(categoryDto.Description))
                {
                    result.Success = false;
                    result.Message = "La categoria es requerida.";
                    return result;

                }
                if (categoryDto.Description.Length > 200)
                {
                    result.Success = false;
                    result.Message = "La descripción de la categoria debe tener 200 carácteres.";
                    return result;
                }

                this.categoryRepository.Update(new Category()
                {
                    categoryid = categoryDto.CategoryId,
                    categoryname = categoryDto.CategoryName,
                    modify_date = categoryDto.ModifyDate,
                    modify_user = categoryDto.ModifyUser,
                    description = categoryDto.Description,
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
    }
}
