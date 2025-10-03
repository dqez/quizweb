using quizweb.Models;

namespace quizweb.Repositories.Interfaces
{
    public interface IAnswerRepository
    {
        Task AddAnswerAsync(Answer answer);
        Task UpdateAnswerAsync(Answer answer);
        Task DeleteAnswerAsync(int id);
    }
}
