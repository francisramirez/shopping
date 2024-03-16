using Microsoft.AspNetCore.Mvc;
using shopping.Api.Dtos.Category;
using shopping.Api.Models;
using shopping.Application.Contracts;
using shopping.Domain.Entities.Production;
using shopping.Infrastructure.Interfaces;


namespace shopping.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService  categoryService)
        {
            this.categoryService =categoryService;
        }

        [HttpGet("GetCategories")]
        public IActionResult Get()
        {
        
            var result = this.categoryService.GetCategories();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }


        [HttpGet("GetCategoryById")]
        public IActionResult Get(int id)
        {
            var result = this.categoryService.GetCategory(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("SaveCategory")]
        public IActionResult Post([FromBody] Application.Dtos.Category.CategoryAddDto  categoryAddModel)
        {

           var result =  this.categoryService.SaveCategory(categoryAddModel);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }

        
        [HttpPost("UpdateCategory")]
        public IActionResult Put([FromBody] Application.Dtos.Category.CategoryUpdteDto categoryUpdte)
        {
            

            var result = this.categoryService.UpdateCategory(categoryUpdte);
           
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

         
        }


        [HttpPost("RemoveCategory")]
        public IActionResult Remove([FromBody] Application.Dtos.Category.CategoryRemoveDto categoryRemove)
        {
            var result = this.categoryService.RemoveCategory(categoryRemove);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
