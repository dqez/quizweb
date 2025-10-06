using quizweb.Models;

namespace quizweb.Repositories.Interfaces
{
    public interface IAnswerRepository
    {
        Task<Answer?> GetAnswerByIdAsync(int id);
        Task<IEnumerable<Answer>> GetAllAnswersByIdQuestionAsync(int idQuestion);
        Task<IEnumerable<Answer>> GetAllAnswersByQSetIdAsync(int idQset);
        Task AddAnswerAsync(Answer answer);
        void UpdateAnswerAsync(Answer answer);
        Task DeleteAnswerAsync(int id);
    }
}
