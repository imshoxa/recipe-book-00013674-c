using Microsoft.EntityFrameworkCore;
using RecipeBook.Models;


namespace RecipeBook.Data
{
    //Student ID 00013674
    public class RecipeBookDbContext: DbContext
    {
        public RecipeBookDbContext(DbContextOptions<RecipeBookDbContext> options) : base(options) { }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
