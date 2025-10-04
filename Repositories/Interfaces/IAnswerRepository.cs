using quizweb.Models;

namespace quizweb.Repositories.Interfaces
{
    public interface IAnswerRepository
    {
        Task AddAnswerAsync(Answer answer);
        void UpdateAnswerAsync(Answer answer);
        Task DeleteAnswerAsync(int id);
    }
}
