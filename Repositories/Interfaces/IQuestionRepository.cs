using quizweb.Models;

namespace quizweb.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        Task<Question?> GetQuestionByIdAsync(int id);
    }
}
