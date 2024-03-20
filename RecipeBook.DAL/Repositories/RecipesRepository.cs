using Microsoft.EntityFrameworkCore;
using RecipeBook.Data;
using RecipeBook.Models;

namespace RecipeBook.Repositories
{
    //Student ID 00013674
    public class RecipesRepository : IRecipesRepository
    {
        private readonly RecipeBookDbContext _dbContext;

        public RecipesRepository(RecipeBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateRecipe(Recipe recipe)
        {
            await _dbContext.Recipes.AddAsync(recipe);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRecipe(int id)
        {
            var recipe = await _dbContext.Recipes.FirstOrDefaultAsync(r => r.Id == id);
            if (recipe != null)
            {
                _dbContext.Recipes.Remove(recipe);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipes()
        {
            var recipes = await _dbContext.Recipes.Include(r => r.User).ToListAsync();
            return recipes;
        }

        public async Task<Recipe> GetSingleRecipe(int id)
        {
            return await _dbContext.Recipes.Include(r => r.User).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task UpdateRecipe(Recipe recipe)
        {
            _dbContext.Entry(recipe).State= EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
