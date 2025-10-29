using quizweb.Models;
using quizweb.Repositories.Interfaces;
using quizweb.Services.Interfaces;

namespace quizweb.Services.Implementations
{
    public class QuestionSetService : IQuestionSetService
    {
        private readonly IQuestionSetRepository _questionSetRepository;

        public QuestionSetService(IQuestionSetRepository questionSetRepository)
        {
            _questionSetRepository = questionSetRepository;
        }

        public async Task<QuestionSet> GetQuestionSetRandomByIdCateAndIdLevel(int idCate, int idLevel)
        {
            var qs = await _questionSetRepository.GetQuestionSetRandomByIdCateAndIdLevel(idCate, idLevel);

            return qs ?? throw new Exception("QuestionSetRandom is not found"); ;
        }

        public async Task<List<QuestionSet>> GetAllCreatedQuestionSetsAsync(string username)
        {
            return await _questionSetRepository.GetAllCreatedQuestionSetsByUsernameAsync(username);
        }

        public async Task<QuestionSet> GetQuestionSetByIdAsync(int id)
        {
            var qs = await _questionSetRepository.GetQuestionSetByIdAsync(id);
            
            return qs ?? throw new Exception("QuestionSetRandom is not found");
        }
    }
}
