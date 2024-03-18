using Microsoft.EntityFrameworkCore;
using RecipeBook.DAL.Data;
using RecipeBook.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//ID_12907

namespace RecipeBook.DAL.Repositories
{
    public class RecipesRepository
    {
        private readonly RecipeBookDbContext _context;

        public RecipesRepository(RecipeBookDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Recipe>> GetAllAsync()
        {
            return await _context.Recipes.Include(r => r.Category).ToListAsync(); // Eager loading of Category
        }

        public async Task<Recipe> GetByIdAsync(int id)
        {
            return await _context.Recipes.Include(r => r.Category).FirstOrDefaultAsync(r => r.Id == id); // Eager loading of Category
        }

        public async Task AddAsync(Recipe recipe)
        {
            await _context.Recipes.AddAsync(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Recipe recipe)
        {
            _context.Recipes.Update(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var recipeToDelete = await _context.Recipes.FindAsync(id);
            _context.Recipes.Remove(recipeToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
//ID_12907
