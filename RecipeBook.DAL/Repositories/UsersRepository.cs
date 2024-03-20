using Microsoft.EntityFrameworkCore;
using RecipeBook.Data;
using RecipeBook.Models;

namespace RecipeBook.Repositories
{
    //Student ID 00013674
    public class UsersRepository : IUsersRepository
    {
        private readonly RecipeBookDbContext _dbContext;

        public UsersRepository(RecipeBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await _dbContext.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetSingleUser(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateUser(User user)
        {
            _dbContext.Entry(user).State= EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
