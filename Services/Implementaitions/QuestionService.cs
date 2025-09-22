using quizweb.Models;
using quizweb.Repositories.Interfaces;
using quizweb.Services.Interfaces;

namespace quizweb.Services.Implementaitions
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<Question?> GetQuestionByIdAsync(int id)
        {
            return await _questionRepository.GetQuestionByIdAsync(id);
        }
    }
}
