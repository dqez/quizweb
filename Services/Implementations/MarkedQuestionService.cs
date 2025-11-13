using quizweb.Models;
using quizweb.Repositories.Interfaces;
using quizweb.Services.Interfaces;
using quizweb.ViewModels.BookMark;

namespace quizweb.Services.Implementations
{
    public class MarkedQuestionService : IMarkedQuestionService
    {
        private readonly IMarkedQuestionRepository _markedQuestionRepository;

        public MarkedQuestionService(IMarkedQuestionRepository markedQuestionRepository)
        {
            _markedQuestionRepository = markedQuestionRepository;
        }

        public async Task<List<MarkedQuestionListViewModel>> GetAllMarkedQuestionsAsync(string username)
        {
            var allMarkedQuestions = await _markedQuestionRepository.GetAllMarkedQuestionsAsync(username);
            return allMarkedQuestions.Select(mq => new MarkedQuestionListViewModel()
            {
                QuestionId = mq.QuestionId,
                MarkedTime = mq.MarkedTime
            }).ToList();

        }

        public async Task AddMarkedQuestion(MarkedQuestion markedQuestion)
        {
            await _markedQuestionRepository.AddMarkedQuestion(markedQuestion);
        }

        public async Task RemoveMarkedQuestion(int id)
        {
            var mq = await _markedQuestionRepository.GetMarkedQuestionByIdAsync(id);
            if (mq != null)
            {
                await _markedQuestionRepository.RemoveMarkedQuestion(mq);
            }
        }
    }
}
