using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//ID_12907

namespace RecipeBook.DAL.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "Title of the recipe is required!")]
        public string Title { get; set; }

        [Required]
        [StringLength(512, ErrorMessage = "Description of the recipe is required!")]
        public string Description { get; set; }

        [Required]
        [Range(1, int.MaxValue)] // Ensures prep time is at least 1 minute
        public int PreparationTime { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
