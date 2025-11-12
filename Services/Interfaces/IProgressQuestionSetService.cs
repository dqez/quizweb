using quizweb.Models;
using quizweb.ViewModels.ProgressQuestionSet;

namespace quizweb.Services.Interfaces
{
    public interface IProgressQuestionSetService
    {
        Task AddProgressQuestionSet(ProgressQuestionSetViewModel viewModel, string username);
        Task UpdateProgressQuestionSet(ProgressQuestionSetViewModel viewModel, string username);
        Task DeleteProgressQuestionSet(string username, int QSetId);
        Task<List<ProgressQuestionSet>> GetAllProgressQuestionSets(string username);
        Task<ProgressQuestionSet?> GetProgressQuestionSetByUsernameAndQSetId(string username, int QSetId);


    }
}
