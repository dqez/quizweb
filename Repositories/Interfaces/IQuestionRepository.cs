using quizweb.Models;

namespace quizweb.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        Task<Question?> GetQuestionByIdAsync(int id);
        Task<IEnumerable<Question>> GetAllQuestionsByIdQSetAsync(int idQSet);
        Task AddQuestionAsync(Question question);
        void UpdateQuestionAsync(Question question);
        void DeleteQuestionAsync(Question question);
        void DeleteQuestionsAsync(IEnumerable<Question> questions);
    }
}
