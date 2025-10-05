using quizweb.Models;

namespace quizweb.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        Task<Question?> GetQuestionByIdAsync(int id);
        Task<IEnumerable<Question>> GetAllQuestionsByIdQSetAsync(int idQSet);
        Task AddQuestionAsync(Question question);
        void UpdateQuestionAsync(Question question);
        Task DeleteQuestionAsync(int id);
    }
}
