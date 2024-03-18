using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeBook.DAL.Models;
using RecipeBook.DAL.Repositories;

namespace RecipeBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [Route("api/[controller]/[action]")]
        [ApiController]
        public class CategoryController : ControllerBase
        {
            private readonly IRepository<Category> _repository;
            public CategoryController(IRepository<Category> repository)
            {
                _repository = repository;
            }

           // GET: api/<CategoryController>
            [HttpGet]
            public async Task<IEnumerable<Category>> Get()
            {
                return await _repository.GetAllAsync();
            }



            // GET api/<CategoryController>/5
            [HttpGet("{id}")]
            public async Task<IActionResult> GetByID(int id)
            {
                var resultedCategory = await _repository.GetByIDAsync(id);
                if (resultedCategory == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(resultedCategory);
                }
            }



            // POST api/<CategoryController>
            [HttpPost]
            public async Task<IActionResult> Create(Category categories)
            {
                await _repository.AddAsync(categories);
                return CreatedAtAction(nameof(GetByID), new { id = categories.ID }, categories);
            }



            // PUT api/<CategoryController>/5
            [HttpPut]
            public async Task<IActionResult> Update(Category categories)
            {
                //if(id!=items.ID) return BadRequest();
                await _repository.UpdateAsync(categories);
                return NoContent();
            }


            // DELETE api/<CategoryController>/5
            [HttpDelete("{id}")]

            public async Task<IActionResult> Delete(int id)
            {
                await _repository.DeleteAsync(id);
                return NoContent();
            }
        }

    }
        
}
