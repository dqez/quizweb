using quizweb.Models;
using quizweb.Repositories.Interfaces;

namespace quizweb.Services.Interfaces
{
    public interface IMarkedQuestionService
    {
        public Task<List<MarkedQuestion>> GetAllMarkedQuestionsAsync(string username);
        public Task AddMarkedQuestion(MarkedQuestion markedQuestion);
        public Task RemoveMarkedQuestion(int id);

    }
}
