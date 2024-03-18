using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//ID_12907

namespace RecipeBook.DAL.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Category name must be at least 2 characters long")]
        public string Name { get; set; }

    }
}
