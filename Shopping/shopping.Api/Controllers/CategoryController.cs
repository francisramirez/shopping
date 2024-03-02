using Microsoft.AspNetCore.Mvc;
using shopping.Api.Dtos.Category;
using shopping.Api.Models;
using shopping.Domain.Entities.Production;
using shopping.Infrastructure.Interfaces;


namespace shopping.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet("GetCategories")]
        public IActionResult Get()
        {
            var categories = this.categoryRepository.GetEntities().Select(cd => new CategoryGetModel()
            {
                CategoryId = cd.categoryid,
                CreationDate = cd.creation_date,
                Description = cd.description,
                Name = cd.categoryname
            });

            return Ok(categories);

        }


        [HttpGet("GetCategoryById")]
        public IActionResult Get(int id)
        {
            var category = this.categoryRepository.GetEntity(id);

            CategoryGetModel categoryGetModel = new CategoryGetModel()
            {
                CategoryId = category.categoryid,
                CreationDate = category.creation_date,
                Description = category.description,
                Name = category.categoryname
            };

            return Ok(categoryGetModel);
        }

        [HttpPost("SaveProduct")]
        public IActionResult Post([FromBody] CategoryAddDto categoryAddModel)
        {
            this.categoryRepository.Save(new Domain.Entities.Production.Category()
            {
                categoryname = categoryAddModel.Name,
                creation_date = categoryAddModel.ChangeDate,
                creation_user = categoryAddModel.UserId,
                description = categoryAddModel.Description
            });

            return Ok("Categoria guardada correctamente.");

        }

        
        [HttpPost("UpdateCategory")]
        public IActionResult Put([FromBody] CategoryUpdteDto categoryUpdte)
        {
            this.categoryRepository.Update(new Category()
            {
                categoryid = categoryUpdte.CategoryId,
                categoryname = categoryUpdte.Name,
                modify_date = categoryUpdte.ChangeDate,
                modify_user = categoryUpdte.UserId,
                description = categoryUpdte.Description,
            });

            return Ok("Categoria actualizada correctamente.");
        }


        [HttpPost("RemoveCategory")]
        public IActionResult Remove([FromBody] CategoryRemoveDto categoryRemove)
        {
            
            this.categoryRepository.Remove(new Category()
            {
                categoryid = categoryRemove.CategoryId,
                delete_date = categoryRemove.ChangeDate,
                delete_user = categoryRemove.UserId
            });

            return Ok("Categoria eliminada correctamente.");
        }
    }
}
