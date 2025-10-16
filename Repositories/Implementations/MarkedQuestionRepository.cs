using Microsoft.EntityFrameworkCore;
using quizweb.Data;
using quizweb.Models;
using quizweb.Repositories.Interfaces;

namespace quizweb.Repositories.Implementations
{
    public class MarkedQuestionRepository : IMarkedQuestionRepository
    {
        private readonly AppDbContext _context;

        public MarkedQuestionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddMarkedQuestion(MarkedQuestion markedQuestion)
        {
            await _context.MarkedQuestions.AddAsync(markedQuestion);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MarkedQuestion>> GetAllMarkedQuestionsAsync(string username)
        {
            return await _context.MarkedQuestions.AsNoTracking().Where(mq => mq.UserName == username).ToListAsync();
        }

        public async Task<MarkedQuestion?> GetMarkedQuestionByIdAsync(int id)
        {
            return await _context.MarkedQuestions.FindAsync(id);
        }

        public async Task RemoveMarkedQuestion(MarkedQuestion markedQuestion)
        {
                _context.MarkedQuestions.Remove(markedQuestion);
                await _context.SaveChangesAsync();
        }
    }
}
