using quizweb.Models;

namespace quizweb.Repositories.Interfaces
{
    public interface IMarkedQuestionRepository
    {
        Task<IEnumerable<MarkedQuestion>> GetAllMarkedQuestionsAsync(string username);
        Task<MarkedQuestion> AddMarkedQuestion(MarkedQuestion markedQuestion);
        Task<MarkedQuestion> RemoveMarkedQuestion(int id);
    }
}
