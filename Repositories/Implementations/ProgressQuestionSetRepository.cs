using Microsoft.EntityFrameworkCore;
using quizweb.Data;
using quizweb.Models;
using quizweb.Repositories.Interfaces;

namespace quizweb.Repositories.Implementations
{
    public class ProgressQuestionSetRepository : IProgressQuestionSetRepository
    {
        private readonly AppDbContext _context;

        public ProgressQuestionSetRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddProgressQuestionSet(ProgressQuestionSet progressQuestionSet)
        {
            await _context.ProgressQuestionSets.AddAsync(progressQuestionSet);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProgressQuestionSet(ProgressQuestionSet progressQuestionSet)
        {
                _context.ProgressQuestionSets.Remove(progressQuestionSet);
                await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProgressQuestionSet>> GetAllProgressQuestionSets(string username)
        {
            return await _context.ProgressQuestionSets.AsNoTracking().Where(pqs => pqs.UserName == username).ToListAsync();
        }

        public async Task<ProgressQuestionSet?> GetProgressQuestionSetById(int id)
        {
            return await _context.ProgressQuestionSets.FindAsync(id);
        }

        public async Task UpdateProgressQuestionSet(ProgressQuestionSet progressQuestionSet)
        {
            _context.ProgressQuestionSets.Update(progressQuestionSet);
            await _context.SaveChangesAsync();
        }
    }
}
