using Microsoft.EntityFrameworkCore;
using quizweb.Data;
using quizweb.Models;
using quizweb.Repositories.Interfaces;

namespace quizweb.Repositories.Implementations
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly AppDbContext _context;

        public AnswerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAnswerAsync(Answer answer)
        {
            await _context.Answers.AddAsync(answer);
            //await _context.SaveChangesAsync(); disable because using UoW
        }

        public async Task DeleteAnswerAsync(int id)
        {
            var answer = await _context.Answers.FindAsync(id);
            if (answer != null)
            {
                _context.Answers.Remove(answer);
                //await _context.SaveChangesAsync(); disable because using UoW
            }
        }

        public async Task<IEnumerable<Answer>> GetAllAnswersByIdQuestionAsync(int idQuestion)
        {
            return await _context.Answers.Where(a => a.QuestionId == idQuestion).ToListAsync();
        }

        public async Task<Answer?> GetAnswerByIdAsync(int id)
        {
            return await _context.Answers.FindAsync(id);
        }

        public void UpdateAnswerAsync(Answer answer)
        {
            _context.Answers.Update(answer);
            //await _context.SaveChangesAsync(); disable because using UoW
        }
    }
}
