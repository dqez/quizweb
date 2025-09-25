using quizweb.Models;
using quizweb.Repositories.Interfaces;
using quizweb.Services.Interfaces;

namespace quizweb.Services.Implementaitions
{
    public class QuestionSetService : IQuestionSetService
    {
        private readonly IQuestionSetRepository _questionSetRepository;

        public QuestionSetService(IQuestionSetRepository questionSetRepository)
        {
            _questionSetRepository = questionSetRepository;
        }

        public async Task<QuestionSet?> GetQuestionSetRandomByIdCateAndIdLevel(int idCate, int idLevel)
        {
           return await _questionSetRepository.GetQuestionSetRandomByIdCateAndIdLevel(idCate, idLevel);
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
