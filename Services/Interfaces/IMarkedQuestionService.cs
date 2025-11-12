using quizweb.Models;
using quizweb.ViewModels.BookMark;
namespace quizweb.Services.Interfaces
{
    public interface IMarkedQuestionService
    {
        public Task<List<MarkedQuestionListViewModel>> GetAllMarkedQuestionsAsync(string username);
        public Task AddMarkedQuestion(MarkedQuestion markedQuestion);
        public Task RemoveMarkedQuestion(int id);

    }
}
