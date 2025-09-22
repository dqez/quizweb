using quizweb.Models;

namespace quizweb.Services.Interfaces
{
    public interface IProgressQuestionSetService
    {
        public Task AddProgressQuestionSet(ProgressQuestionSet progressQuestionSet);
        public Task UpdateProgressQuestionSet(ProgressQuestionSet progressQuestionSet);
        public Task DeleteProgressQuestionSet(int id);
        public Task<List<ProgressQuestionSet>> GetAllProgressQuestionSets(string username);
        public Task<ProgressQuestionSet> GetProgressQuestionSetById(int id);

    }
}
