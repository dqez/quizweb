using quizweb.Models;
using quizweb.Repositories.Interfaces;

namespace quizweb.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        public Task AddUserAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser?> GetProfileAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProfile(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}
