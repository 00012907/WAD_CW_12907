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
    public class CategoriesRepository
    {
        public class CategoryRepository : IRepository<Category>
        {
            private readonly RecipeBookDbContext _context;

            public CategoryRepository(RecipeBookDbContext context)
            {
                _context = context;
            }

            // Add or create new entity
            public async Task AddAsync(Category categories)
            {
                await _context.Categories.AddAsync(categories);
                await _context.SaveChangesAsync();
            }

            // Delete an entity
            public async Task DeleteAsync(int id)
            {
                var entity = await _context.Categories.FindAsync(id);
                if (entity != null)
                {
                    _context.Categories.Remove(entity);
                    await _context.SaveChangesAsync();
                }
            }

            // Retrieve all entity from the database
            public async Task<IEnumerable<Category>> GetAllAsync() => await _context.Categories.ToArrayAsync();

            // Retrieve an entity from database using only an id
            public async Task<Category> GetByIDAsync(int id) => await _context.Categories.FindAsync(id);

            // Update the entity
            public async Task UpdateAsync(Category categories)
            {
                _context.Entry(categories).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
//ID_12907
