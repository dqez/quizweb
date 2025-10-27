using quizweb.Models;
using quizweb.ViewModels;

namespace quizweb.Services.Interfaces
{
    public interface IProgressQuestionSetService
    {
        public Task AddProgressQuestionSet(ProgressQuestionSetViewModel viewModel, string username);
        public Task UpdateProgressQuestionSet(ProgressQuestionSet progressQuestionSet);
        public Task DeleteProgressQuestionSet(int id);
        public Task<List<ProgressQuestionSet>> GetAllProgressQuestionSets(string username);
        public Task<ProgressQuestionSet> GetProgressQuestionSetById(int id);

    }
}
