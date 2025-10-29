using quizweb.Models;

namespace quizweb.Repositories.Interfaces
{
    public interface IMarkedQuestionRepository
    {
        Task<List<MarkedQuestion>> GetAllMarkedQuestionsAsync(string username);
        Task<MarkedQuestion?> GetMarkedQuestionByIdAsync(int id);
        Task AddMarkedQuestion(MarkedQuestion markedQuestion);
        Task RemoveMarkedQuestion(MarkedQuestion markedQuestion);
    }
}
