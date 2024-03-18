using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeBook.DAL.Models;
using RecipeBook.DAL.Repositories;

namespace RecipeBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRepository<Recipe> _recipeRepository;

        public RecipesController(IRepository<Recipe> recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Recipe>> GetAll() => await _recipeRepository.GetAllAsync();

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Recipe), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var resultRecipe = await _recipeRepository.GetByIDAsync(id);
            return resultRecipe == null ? NotFound() : Ok(resultRecipe);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Recipe recipe)
        {
            await _recipeRepository.AddAsync(recipe);
            return CreatedAtAction(nameof(GetById), new { id = recipe.Id }, recipe);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Recipe recipe)
        {
            //if (id != recipe.Id) return BadRequest();
            await _recipeRepository.UpdateAsync(recipe);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _recipeRepository.DeleteAsync(id);
            return NoContent();
        }
    }

}
