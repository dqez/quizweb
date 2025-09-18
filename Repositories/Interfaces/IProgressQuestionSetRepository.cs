using quizweb.Models;

namespace quizweb.Repositories.Interfaces
{
    public interface IProgressQuestionSetRepository
    {
        Task<IEnumerable<ProgressQuestionSet>> GetAllProgressQuestionSets(string username);
        Task<ProgressQuestionSet?> GetProgressQuestionSetById(int id);
        Task AddProgressQuestionSet(ProgressQuestionSet progressQuestionSet);
        Task UpdateProgressQuestionSet(ProgressQuestionSet progressQuestionSet);
        Task DeleteProgressQuestionSet(int id);

    }
}
