using quizweb.Models;

namespace quizweb.Services.Interfaces
{
    public interface IQuestionSetService
    {
        public Task<QuestionSet?> GetQuestionSetRandomByIdCateAndIdLevel(int idCate, int idLevel);
        public Task<List<QuestionSet>> GetAllCreatedQuestionSetsAsync(string username);
        public Task<QuestionSet?> GetQuestionSetByIdAsync(int id);

    }
}
