using quizweb.Models;
using quizweb.Repositories.Interfaces;

namespace quizweb.Services
{
    public class QuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<Question> GetQuestionByIdAsync(int id)
        {
            return await _questionRepository.GetQuestionByIdAsync(id);
        }
    }
}
