using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Build.Framework;
using RecipeBook.Data;
using Xunit;
using Xunit.Sdk;

namespace RecipeBook.Models
{
    //Student ID 00013674
    public class Recipe
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name of the recipe is required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description of the recipe is required!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "User of the recipe is required!")]
        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set;  }

    }

}
