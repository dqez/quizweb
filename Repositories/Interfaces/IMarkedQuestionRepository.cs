using quizweb.Models;

namespace quizweb.Repositories.Interfaces
{
    public interface IMarkedQuestionRepository
    {
        Task<IEnumerable<MarkedQuestion>> GetAllMarkedQuestionsAsync(string username);
        Task AddMarkedQuestion(MarkedQuestion markedQuestion);
        Task RemoveMarkedQuestion(int id);
    }
}
