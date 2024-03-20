using RecipeBook.Models;

namespace RecipeBook.Repositories
{
    //Student ID 00013674
    public interface IRecipesRepository
    {
        Task<IEnumerable<Recipe>> GetAllRecipes();
        Task<Recipe> GetSingleRecipe(int id);
        Task CreateRecipe(Recipe recipe);
        Task UpdateRecipe(Recipe recipe);
        Task DeleteRecipe(int id);
    }
}
