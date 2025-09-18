using quizweb.Models;
using quizweb.Repositories.Interfaces;

namespace quizweb.Services
{
    public class QuestionSetService
    {
        private readonly IQuestionSetRepository _questionSetRepository;

        public QuestionSetService(IQuestionSetRepository questionSetRepository)
        {
            _questionSetRepository = questionSetRepository;
        }

        public async Task<QuestionSet> GetQuestionSetRandomByIdCateAndIdLevel(int idCate, int idLevel)
        {
            var qsRand = await _questionSetRepository.GetQuestionSetRandomByIdCateAndIdLevel(idCate, idLevel);
            if (qsRand == null)
            {
                throw new Exception("No question set found for the given category and level.");
            }
            return qsRand;
        }

        public async Task<List<QuestionSet>> GetAllCreatedQuestionSetsAsync(string username)
        {
            return (await _questionSetRepository.GetAllCreatedQuestionSetsByUsernameAsync(username)).ToList();
        }

        public async Task<QuestionSet?> GetQuestionSetByIdAsync(int id)
        {
            return await _questionSetRepository.GetQuestionSetByIdAsync(id);
        }
    }
}
