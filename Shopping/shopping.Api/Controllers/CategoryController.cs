using Microsoft.AspNetCore.Mvc;
using shopping.Api.Models;
using shopping.Infrastructure.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
            var categories = this.categoryRepository.GetEntities().Select(cd => new CategoryAddModel()
            {
                CategoryId = cd.categoryid,
                CreateDate = cd.creation_date,
                CreateUser = cd.creation_user,
                Description = cd.description,
                Name = cd.categoryname
            });

            return Ok(categories);

        }


        [HttpGet("GetCategoryById")]
        public IActionResult Get(int id)
        {
            var category = this.categoryRepository.GetEntity(id);
            return Ok(category);
        }

        // POST api/<CategoryController>
        [HttpPost("SaveProduct")]
        public void Post([FromBody] CategoryAddModel categoryAddModel)
        {
            this.categoryRepository.Save(new Domain.Entities.Production.Category()
            {
                categoryname = categoryAddModel.Name,
                creation_date = categoryAddModel.CreateDate,
                creation_user = categoryAddModel.CreateUser,
                description = categoryAddModel.Description
            });


        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
