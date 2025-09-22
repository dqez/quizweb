using Microsoft.EntityFrameworkCore;
using quizweb.Data;
using quizweb.Models;
using quizweb.Repositories.Interfaces;

namespace quizweb.Repositories.Implementations
{
    public class QuestionSetRepository : IQuestionSetRepository
    {
        private readonly AppDbContext _context;

        public QuestionSetRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddQuestionSetAsync(QuestionSet questionSet)
        {
            await _context.QuestionSets.AddAsync(questionSet);
        }

        public async Task DeleteQuestionSetAsync(int id)
        {
            var qs = await _context.QuestionSets.FindAsync(id);
            if (qs != null)
            {
                _context.QuestionSets.Remove(qs);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<QuestionSet>> GetAllCreatedQuestionSetsByUsernameAsync(string username)
        {
            return await _context.QuestionSets.Where(qs => qs.AuthorName == username).ToListAsync();
        }

        public async Task<QuestionSet?> GetQuestionSetByIdAsync(int id)
        {
            return await _context.QuestionSets.FirstOrDefaultAsync(qs => qs.QSetId == id);
        }

        public async Task<QuestionSet?> GetQuestionSetRandomByIdCateAndIdLevel(int idCate, int idLevel)
        {
            var count = await _context.QuestionSets.CountAsync(qs => qs.CategoryId == idCate && qs.LevelId == idLevel);
            if (count == 0)
            {
                return null;
            }

            var rand = new Random();
            var randIndex = rand.Next(count);

            return await _context.QuestionSets
                .Where(qs => qs.CategoryId == idCate && qs.LevelId == idLevel)
                .Skip(randIndex)
                .FirstOrDefaultAsync();
        }

        public Task UpdateQuestionSetAsync(QuestionSet questionSet)
        {
            throw new NotImplementedException();
        }
    }
}
