using quizweb.Models;
using quizweb.Repositories.Interfaces;
using quizweb.Services.Interfaces;

namespace quizweb.Services.Implementaitions
{
    public class MarkedQuestionService : IMarkedQuestionService
    {
        private readonly IMarkedQuestionRepository _markedQuestionRepository;

        public MarkedQuestionService(IMarkedQuestionRepository markedQuestionRepository)
        {
            _markedQuestionRepository = markedQuestionRepository;
        }

        public async Task<List<MarkedQuestion>> GetAllMarkedQuestionsAsync(string username)
        {
            return (await _markedQuestionRepository.GetAllMarkedQuestionsAsync(username)).ToList();
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
