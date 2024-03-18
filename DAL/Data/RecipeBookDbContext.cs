using Microsoft.EntityFrameworkCore;
using RecipeBook.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.DAL.Data
{
    public  class RecipeBookDbContext:DbContext
    {
        public RecipeBookDbContext(DbContextOptions<RecipeBookDbContext> options) : base(options) { }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
