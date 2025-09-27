using Microsoft.EntityFrameworkCore;
using quizweb.Data;
using quizweb.Models;
using quizweb.Repositories.Interfaces;
using SQLitePCL;

namespace quizweb.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<QuestionSet>> GetCreatedQuestionSetsAsync(string username)

        {
            return await _context.QuestionSets.Where(qs => qs.AuthorName == username).ToListAsync();
        }

        public async Task<IEnumerable<MarkedQuestion>> GetMarkedQuestionAsync(string username)

        {
            return await _context.MarkedQuestions.Where(mq => mq.UserName == username).ToListAsync();
        }

        public async Task<IEnumerable<ProgressQuestionSet>> GetProgressQuestionSetsAsync(string username)

        {
            return await _context.ProgressQuestionSets.Where(pqs => pqs.UserName == username).ToListAsync();
        }

        public async Task<ApplicationUser?> GetProfileAsync(string username)

        {
            return await _context.Users.Where(u => u.UserName == username).FirstOrDefaultAsync();
        }

        public async Task UpdateProfileAsync(ApplicationUser user)

        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
