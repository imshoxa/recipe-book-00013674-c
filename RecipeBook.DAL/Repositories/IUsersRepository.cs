using RecipeBook.Models;

namespace RecipeBook.Repositories
{
    //Student ID 00013674
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetSingleUser(int id);
        Task CreateUser(User recipe);
        Task UpdateUser(User recipe);
        Task DeleteUser(int id);
    }
}
